using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private List<Vector2> positions;
    [SerializeField] private float threshold = 0.0001f;
    private int currentIndex = 0;

    private void Update()
    {
        Vector2 nextPosition = positions[currentIndex];
        Vector2 currentPosition = transform.position;

        Vector2 directionToNextPos = nextPosition - currentPosition;
        directionToNextPos.Normalize();

        characterMovement.SetDirection(directionToNextPos);


        if ((currentPosition - nextPosition).magnitude <= threshold)
        {
            currentIndex++;
            if (currentIndex >= positions.Count)
            {
                currentIndex = 0;
            }
        }
    }
}
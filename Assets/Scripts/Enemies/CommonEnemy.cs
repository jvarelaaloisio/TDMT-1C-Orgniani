using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement targetPosition;

    private float distance;
    [SerializeField] private float startFollowingDistance = 4f;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPosition.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            if(distance < startFollowingDistance)
            {
                //TODO: TP2 - Unclear logic
                startFollowingDistance = 1000f;
                characterMovement.SetDirection(directionToNextPos);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement target;

    private float distance;
    [SerializeField] private float startFollowingDistance = 4f;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (target == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = target.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            if(distance < startFollowingDistance)
            {
                startFollowingDistance = 1000f;
                characterMovement.SetDirection(directionToNextPos);
            }
        }
    }
}

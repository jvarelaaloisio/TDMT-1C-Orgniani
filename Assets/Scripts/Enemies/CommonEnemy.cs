using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement target;

    private void Update()
    {
        if (target == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = target.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            characterMovement.SetDirection(directionToNextPos);

        }
    }
}

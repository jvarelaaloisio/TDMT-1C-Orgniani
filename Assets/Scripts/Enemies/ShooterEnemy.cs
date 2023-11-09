using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthController targetHP;

    private float distance;
    [SerializeField] private float startShootingDistance = 4f;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (enemyHP.HP > 0 && targetHP.HP > 0)
        {
            if (attack == null)
            {
                Debug.LogError($"{name}: CharacterShooting is null!");
                return;
            }

            if (targetPosition == null)
                Debug.LogError($"{name}: Target is null!");

            else
            {
                Vector2 currentPosition = transform.position;
                Vector2 nextPosition = targetPosition.currentPosition;

                Vector2 directionToNextPos = nextPosition - currentPosition;

                if (distance < startShootingDistance)
                {
                    attack.Shoot(directionToNextPos);
                }
            }
        }
    }
}

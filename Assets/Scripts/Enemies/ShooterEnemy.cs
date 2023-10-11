using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthPoints enemyHP;
    [SerializeField] private CharacterMovement target;
    [SerializeField] private HealthPoints targetHP;

    private void Update()
    {
        if (enemyHP.HP > 0 && targetHP.HP > 0)
        {
            if (attack == null)
            {
                Debug.LogError($"{name}: Gun is null! </3");
                return;
            }

            if (target == null)
                Debug.LogError($"{name}: Target is null!");

            else
            {
                Vector2 currentPosition = transform.position;
                Vector2 nextPosition = target.currentPosition;

                Vector2 directionToNextPos = nextPosition - currentPosition;

                attack.Shoot(directionToNextPos);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthPoints enemyHP;

    [SerializeField] private CharacterMovement target;
    [SerializeField] private HealthPoints targetHP;

    private void Update()
    {
        if (enemyHP.HP > 0 && targetHP.HP > 0)
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (attack == null)
        {
            Debug.LogError($"{name}: CharacterShooting is null!");
            return;
        }

        if (target == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = target.currentPosition;
            Vector2 nextPosition2 = target.currentPosition - new Vector2(3, 0);
            Vector2 nextPosition3 = target.currentPosition + new Vector2(3, 0);

            Vector2 directionToNextPos = nextPosition - currentPosition;
            Vector2 directionToNextPos2 = nextPosition2 - currentPosition;
            Vector2 directionToNextPos3 = nextPosition3 - currentPosition;

            attack.BossShoot(directionToNextPos, directionToNextPos2, directionToNextPos3);
        }
    }
}

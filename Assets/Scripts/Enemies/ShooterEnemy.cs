using System.Collections;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private CharacterMovement targetPosition;

    [SerializeField] private HealthController targetHP;

    private bool isShooting = true;
    [SerializeField] private float attackCooldown = 5f;

    private float targetDistance;
    [SerializeField] private float startShootingDistance = 4f;

    private void OnEnable()
    {
        targetHP.onDead += StopShootingTarget;
    }

    private void OnDisable()
    {
        targetHP.onDead -= StopShootingTarget;
    }

    private void Update()
    {
        if (!isShooting) return;

        if (attack == null)
        {
            Debug.LogError($"{name}: CharacterShooting is null!");
            return;
        }

        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            targetDistance = Vector2.Distance(transform.position, targetPosition.transform.position);

            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPosition.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;

            if (targetDistance < startShootingDistance)
                attack.Shoot(directionToNextPos);

            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        isShooting = false;

        yield return new WaitForSeconds(attackCooldown);

        isShooting = true;
    }

    private void StopShootingTarget()
    {
        enabled = false;
    }
}

using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement targetPosition;

    [SerializeField] private HealthController enemyHP;

    private float distance;
    private bool shouldFollowTarget = false;
    [SerializeField] private float startFollowingDistance = 4f;

    private void OnEnable()
    {
        enemyHP.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        enemyHP.onDead -= HandleDeath;
    }

    private void Update()
    {
        FollowTarget();
    }

    public void FollowTarget()
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

            //TODO: TP2 - Unclear logic --> DONE
            if (distance < startFollowingDistance)
                shouldFollowTarget = true;

            if (enemyHP.HP < enemyHP.maxHP)
                shouldFollowTarget = true;

            if (shouldFollowTarget)
                characterMovement.SetDirection(directionToNextPos);
        }
    }

    private void HandleDeath()
    {
        if (TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        if (TryGetComponent(out CharacterMovement movement))
            movement.enabled = false;

        if (TryGetComponent(out CharacterShooting attack))
            attack.enabled = false;
    }
}

using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement targetPosition;

    [SerializeField] private HealthController enemyHP;

    private float targetDistance;
    private bool shouldFollowTarget = false;
    [SerializeField] private float startFollowingDistance = 4f;

    private void Update()
    {
        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            targetDistance = Vector2.Distance(transform.position, targetPosition.transform.position);

            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPosition.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            //TODO: TP2 - Unclear logic --> DONE
            if (targetDistance < startFollowingDistance || enemyHP.HP < enemyHP.maxHP)
                shouldFollowTarget = true;

            if (shouldFollowTarget)
                characterMovement.SetDirection(directionToNextPos);
        }
    }
}

using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement targetPosition;

    private float distance;
    private bool shouldFollowTarget = false;
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

            //TODO: TP2 - Unclear logic --> DONE
            if (distance < startFollowingDistance)
                shouldFollowTarget = true;

            if (shouldFollowTarget)
                characterMovement.SetDirection(directionToNextPos);
        }
    }
}

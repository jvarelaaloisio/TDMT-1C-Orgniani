using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthController playerHP;

    private void OnEnable()
    {
        playerHP.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        playerHP.onDead -= HandleDeath;
    }

    private void OnParticleCollision()
    {
        if(TryGetComponent(out HealthController playerHP))
        {
            playerHP.TakeDamage(1);
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

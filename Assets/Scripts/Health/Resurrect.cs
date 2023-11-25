using UnityEngine;

public class Resurrect : MonoBehaviour
{
    [SerializeField] HealthController HP;
    [SerializeField] private GameObject respawnPoint;

    private void OnEnable()
    {
        HP.onDead += HandleResurrection;
    }

    private void OnDisable()
    {
        HP.onDead -= HandleResurrection;
    }

    private void HandleResurrection()
    {
        transform.position = respawnPoint.transform.position;

        HP.HP = HP.maxHP;
        HP.canHurt = true;

        if (TryGetComponent(out Collider2D collider))
            collider.enabled = true;

        if (TryGetComponent(out CharacterMovement movement))
            movement.enabled = true;

        if (TryGetComponent(out CharacterShooting attack))
            attack.enabled = true;
    }
}

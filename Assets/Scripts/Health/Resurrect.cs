using UnityEngine;

public class Resurrect : MonoBehaviour
{
    [SerializeField] private HealthController HP;
    [SerializeField] private Collider2D characterCollider;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterShooting attack;
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

        characterCollider.enabled = true;
        characterMovement.enabled = true;

        if(attack != null )
            attack.enabled = true;

    }
}

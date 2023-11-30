using UnityEngine;

[RequireComponent(typeof(Animator))]

//TODO: TP2 - Fix - File name. NO SPACES!! --> DONE
public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController hurtAndDead;

    [SerializeField] private string animatorParameterDirX = "dir_x";
    [SerializeField] private string animatorParameterDirY = "dir_y";
    [SerializeField] private string animatorParameterIsMoving = "is_moving";

    [SerializeField] private string animatorParameterAttack = "attack";
    [SerializeField] private string animatorParameterHurt = "hurt";
    [SerializeField] private string animatorParameterIsDead = "is_dead";

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(attack != null)
            attack.onShoot += HandleShoot;

        hurtAndDead.onHurt += HandleHurt;
        hurtAndDead.onDead += HandleDead;
    }

    private void OnDisable()
    {
        if (attack != null)
            attack.onShoot -= HandleShoot;

        hurtAndDead.onHurt -= HandleHurt;
        hurtAndDead.onDead -= HandleDead;
    }

    private void Update()
    {
        Vector2 direction = characterMovement.direction;

        float dirX = direction.x;
        float dirY = direction.y;
        bool isMoving = direction != Vector2.zero;

        animator.SetBool(animatorParameterIsMoving, isMoving);

        if (isMoving)
        {
            animator.SetFloat(animatorParameterDirX, dirX);
            animator.SetFloat(animatorParameterDirY, dirY);
        }
    }

    private void HandleShoot()
    {
        animator.SetTrigger(animatorParameterAttack);
    }

    private void HandleHurt()
    {
        animator.SetTrigger(animatorParameterHurt);
    }

    private void HandleDead()
    {
        animator.SetBool(animatorParameterIsDead, true);
    }
}
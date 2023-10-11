using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterShooting _attack;
    [SerializeField] private HealthPoints _hurtAndDead;

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

    private void Update()
    {
        Vector2 direction = _characterMovement._direction;
        bool isShooting = _attack._isShooting;
        bool isHurt = _hurtAndDead._isHurt;
        bool isDead = _hurtAndDead._isDead;

        float dirX = direction.x;
        float dirY = direction.y;
        bool isMoving = direction != Vector2.zero;

        animator.SetBool(animatorParameterIsMoving, isMoving);

        if (isMoving)
        {
            animator.SetFloat(animatorParameterDirX, dirX);
            animator.SetFloat(animatorParameterDirY, dirY);
        }

        if (isShooting)
        {
            animator.SetTrigger(animatorParameterAttack);
        }

        if (isHurt)
        {
            animator.SetTrigger(animatorParameterHurt);
        }

        if (isDead)
        {
            animator.SetBool(animatorParameterIsDead, isDead);
        }


    }
}
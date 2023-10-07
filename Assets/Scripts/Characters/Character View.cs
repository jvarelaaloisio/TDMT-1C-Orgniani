using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Gun _attack;
    [SerializeField] private HealthPoints _hurtAndDeath;

    [SerializeField] private string animatorParameterDirX = "dir_x";
    [SerializeField] private string animatorParameterDirY = "dir_y";
    [SerializeField] private string animatorParameterIsMoving = "is_moving";

    [SerializeField] private string animatorParameterAttack = "attack";

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 direction = _characterMovement._direction;
        bool isShooting = _attack._isShooting;

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


    }
}
using System;
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

    private void OnEnable()
    {
        _attack.onShoot += HandleShoot;
        _hurtAndDead.onHurt += HandleHurt;
        _hurtAndDead.onDead += HandleDead;
    }

    private void OnDisable()
    {
        _attack.onShoot -= HandleShoot;
        _hurtAndDead.onHurt -= HandleHurt;
        _hurtAndDead.onDead -= HandleDead;
    }

    private void Update()
    {
        Vector2 direction = _characterMovement._direction;

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
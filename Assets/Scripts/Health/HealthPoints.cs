using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;

    [SerializeField] private bool shouldDestroyOnDeath;
    [SerializeField] private bool isEnemy;

    [SerializeField] private float hurtCooldown = 1f;
    private float currentTime = 0;
    private bool canHurt = true;

    public VoidDelegateType onHurt;
    public VoidDelegateType onDead;

    private void Update()
    {
        if (!canHurt)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= hurtCooldown)
            {
                canHurt = true;
                currentTime = 0;
            }
        }
    }

    public void TakeDamage(int value)
    {
        if (!canHurt) return;

        if (isEnemy && value == 1) return;

        HP -= value;

        if (onHurt != null)
        {
            onHurt();
        }

        if (HP <= 0)
        {
            Die();
        }

        canHurt = false;
    }

    private void Die()
    {
        Debug.LogError($"{name}: Character died!");

        if (onDead != null)
        {
            onDead();
        }

        if (shouldDestroyOnDeath)
        {
            //Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            //Destroy(gameObject, 0.5f); HACE QUE SE DESTRUYAN DESPUÉS DE UN RATO
            Destroy(gameObject);
        }

        else
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CharacterMovement>().enabled = false;
            GetComponent<CharacterShooting>().enabled = false;

            if (GetComponent<CommonEnemy>() != null) GetComponent<CommonEnemy>().enabled = false;

            if(isEnemy)
            {
                Destroy(gameObject, 2f);
            }
        }

    }
}
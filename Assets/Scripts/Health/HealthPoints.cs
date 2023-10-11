using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;

    [SerializeField] bool shouldDestroyOnDeath;
    [SerializeField] bool isEnemy;

    [SerializeField] private float hurtCooldown = 1f;
    private float currentTime = 0;
    public bool canHurt = true;

    public bool _isHurt = false;
    public bool _isDead = false;

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

            _isHurt = false;
        }

        _isDead = false;
    }

    public void TakeDamage(int value)
    {
        if (!canHurt) return;

        if (isEnemy && value == 1) return;

        HP -= value;
        _isHurt = true;

        if (HP <= 0)
        {
            Die();
        }

        canHurt = false;
    }

    private void Die()
    {
        Debug.LogError($"{name}: Character died!");

        _isDead = true;

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

            if (GetComponent<CommonEnemy>() != null) GetComponent<CommonEnemy>().enabled = false;

            GetComponent<Gun>().enabled = false;

            //this.enabled = false;

            //Destroy(gameObject, 1f); //HACE QUE SE DESTRUYAN DESPUÉS DE UN RATO
        }

    }
}
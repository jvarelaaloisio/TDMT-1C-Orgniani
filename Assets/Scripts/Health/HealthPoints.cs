using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;

    [SerializeField] bool shouldDestroyOnDeath;

    [SerializeField] Animator animator;

    public void TakeDamage (int value)
    {
        HP -= value;

        if(animator != null)
        {
            animator.SetTrigger("hurt");
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.LogError($"{name}: Character died!");

        if (animator != null)
        {
            animator.SetBool("is_dead", true);
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

            if(GetComponent<CommonEnemy>() != null) GetComponent<CommonEnemy>().enabled = false;

            GetComponent<Gun>().enabled = false;
            this.enabled = false;

            //Destroy(gameObject, 1f); //HACE QUE SE DESTRUYAN DESPUÉS DE UN RATO
        }
    }
}

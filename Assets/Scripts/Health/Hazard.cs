using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject playerGameObject = col.gameObject;

        HealthPoints playerHP = playerGameObject.GetComponent<HealthPoints>();

        if (playerHP)
            playerHP.TakeDamage(damage);

        else
            Debug.LogError($"{name}: Character HP is null");
    }
}
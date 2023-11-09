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

        //TODO: TP2 - Optimization - TryGetComponent
        HealthController playerHP = playerGameObject.GetComponent<HealthController>();

        if (playerHP)
            playerHP.TakeDamage(damage);
    }
}
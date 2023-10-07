using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Si yo soy la bullet, col.gameObject es el player
        GameObject playerGameObject = col.gameObject;

        //GetComponent busca entre los componentes y me devuelv el primero del tipo que le pedi

        HealthPoints playerHP = playerGameObject.GetComponent<HealthPoints>();

        if (playerHP != null) //es lo mismo que if(playerHP)
            playerHP.TakeDamage(damage);

        else
            Debug.LogError($"{name}: Player HP is null");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

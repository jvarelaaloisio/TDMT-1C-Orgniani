using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] HealthPoints characterHP;
    [SerializeField] private GameOverScreen screen;

    private void Update()
    {
        if (characterHP.HP <= 0)
        {
            screen.Setup();
        }
    }
}

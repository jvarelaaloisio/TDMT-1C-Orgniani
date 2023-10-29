using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private HealthPoints characterHP;
    [SerializeField] private GameOverScreen screen;
    [SerializeField] private AudioSource gameMusic;

    private void Update()
    {
        if (characterHP.HP <= 0)
        {
            screen.Setup();
            gameMusic.Stop();
        }
    }
}

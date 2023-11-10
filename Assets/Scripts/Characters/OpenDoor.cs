using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Subsystems;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private AudioSource winLevelSoundEffect;

    private int currentSpriteIndex;

    private void OnEnable()
    {
        if (sprites.Count < 1)
        {
            Debug.LogError($"{name}: No sprites were found." +
                $"\n Disabling component");
            enabled = false;
        }
    }

    private void Update()
    {
        //TODO: TP2 - Optimization - Should be event based
        KillCounter();

        //TODO: TP2 - Optimization - Should be event based
        if (enemies.Count == 0)
        {
            currentSpriteIndex++;

            if (currentSpriteIndex >= sprites.Count)
            {
                enabled = false;
                return;
            }

            spriteRenderer.sprite = sprites[currentSpriteIndex];

            //TODO: TP2 - Fix - Possible null reference
            GetComponent<Collider2D>().enabled = false;

            winLevelSoundEffect.Play();
        }
    }

    private void KillCounter()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            //TODO: TP2 - Optimization - Cache values/refs
            if (enemies[i].GetComponent<Collider2D>().enabled == false)
                enemies.Remove(enemies[i]);
        }
    }

    public void DamageAllEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            //TODO: TP2 - Optimization - Cache values/refs
            var HP = enemies[i].GetComponent<HealthController>();
            HP.TakeDamage(3);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
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

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            //TODO: TP2 - Optimization - Cache values/refs --> ASK
            if (enemies[i].TryGetComponent(out HealthController enemyHP))
                enemyHP.onDead += KillCounter;
        }
    }

    //TODO: TP2 - Optimization - Should be event based --> DONE
    private void KillCounter()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].TryGetComponent(out HealthController enemyHP))
            {
                if(enemyHP.HP <= 0)
                {
                    enemies.Remove(enemies[i]);
                    enemyHP.onDead -= KillCounter;
                }
            }
        }

        //TODO: TP2 - Optimization - Should be event based --> DONE
        if (enemies.Count == 0)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= sprites.Count)
        {
            enabled = false;
            return;
        }

        spriteRenderer.sprite = sprites[currentSpriteIndex];

        //TODO: TP2 - Fix - Possible null reference --> DONE
        if (TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        winLevelSoundEffect.Play();
    }

    public void DamageAllEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].activeSelf)
            {
                //TODO: TP2 - Optimization - Cache values/refs --> ASK
                if (enemies[i].TryGetComponent(out HealthController health))
                    health.TakeDamage(3);
            }
        }
    }
}

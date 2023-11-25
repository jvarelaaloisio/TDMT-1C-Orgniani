using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<HealthController> enemies;

    [SerializeField] private AudioSource winLevelSoundEffect;

    private int currentSpriteIndex;

    public VoidDelegateType onDamageAll;

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
            //TODO: TP2 - Optimization - Cache values/refs --> DONE
            enemies[i].onDead += KillCounter;
        }
    }

    //TODO: TP2 - Optimization - Should be event based --> DONE
    private void KillCounter()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].HP <= 0)
            {
                enemies.Remove(enemies[i]);
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
            enemies[i].TakeDamage(3);
            if (onDamageAll != null) onDamageAll();
        }
    }
}

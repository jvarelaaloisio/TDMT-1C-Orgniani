using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private AudioSource openSoundEffect;

    private int currentSpriteIndex;
    private bool isOpen= false;

    private void OnEnable()
    {
        if (sprites.Count < 1)
        {
            Debug.LogError($"{name}: No sprites were found." +
                $"\n Disabling component"); // \n SIGNIFICA ENTER
            enabled = false;
        }
    }

    private void Update()
    {
        KillCounter();

        if (enemies.Count == 0)
        {
            Debug.LogError($"{name}: List of enemies is empty.");

            currentSpriteIndex++;

            if (currentSpriteIndex >= sprites.Count)
            {
                enabled = false;
                isOpen = true;
                return;
            }

            spriteRenderer.sprite = sprites[currentSpriteIndex];

            GetComponent<Collider2D>().enabled = false;

            openSoundEffect.Play();
        }
    }

    private void KillCounter()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
            }
        }
    }
}

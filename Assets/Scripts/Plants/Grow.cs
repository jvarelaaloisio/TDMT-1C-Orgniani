using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float growthCooldown = 1f;
    private int currentSpriteIndex;
    private float currentTime = 0;
    public bool isFullyGrown = false;

    private void OnEnable()
    {
        if(sprites.Count < 1)
        {
            Debug.LogError($"{name}: No sprites were found." + 
                $"\n Disabling component"); // \n SIGNIFICA ENTER
            enabled = false;
        }
    }

    private void Update()
    {
        if(currentTime >= growthCooldown)
        {
            currentSpriteIndex++;

            if(currentSpriteIndex >= sprites.Count)
            {
                enabled = false;
                isFullyGrown = true;
                return;
            }

            spriteRenderer.sprite = sprites[currentSpriteIndex];
            currentTime -= growthCooldown;
        }

        currentTime += Time.deltaTime;
    }
}

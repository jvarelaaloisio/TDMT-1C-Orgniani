using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private BossEnemy bossEnemy;
    [SerializeField] private GameObject bossFrogRedSprite;
    [SerializeField] private GameObject bossFrogGreenSprite;

    [SerializeField] private AudioSource spriteChanged;


    private void OnEnable()
    {
        bossEnemy.onAttackChange += ReplaceSprite;
    }

    private void OnDisable()
    {
        bossEnemy.onAttackChange -= ReplaceSprite;
    }

    private void ReplaceSprite()
    {
        if(bossFrogRedSprite.activeSelf && !bossEnemy.isTripleShooting)
        {
            bossFrogRedSprite.SetActive(false);
            bossFrogGreenSprite.SetActive(true);
            spriteChanged.Play();
        }

        else if (bossFrogGreenSprite.activeSelf && !bossEnemy.isExplodingShooting)
        {
            bossFrogGreenSprite.SetActive(false);
            bossFrogRedSprite.SetActive(true);
            spriteChanged.Play();
        }

    }

}

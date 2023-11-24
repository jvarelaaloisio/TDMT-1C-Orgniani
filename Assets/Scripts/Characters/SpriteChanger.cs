using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEditor.Animations;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private BossEnemy bossEnemy;
    [SerializeField] private GameObject bossFrogRedSprite;
    [SerializeField] private GameObject bossFrogGreenSprite;

    [SerializeField] private AudioSource spriteChanged;
    [SerializeField] private AudioSource callFrogs;

    [SerializeField] private Animator animator;
    [SerializeField] private string animatorParameterCallFrogs = "call_frogs";

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
        if(bossEnemy.isTripleShooting)
        {
            bossFrogRedSprite.SetActive(false);
            bossFrogGreenSprite.SetActive(true);
            spriteChanged.Play();
        }

        if (bossEnemy.isExplodingShooting)
        {
            animator.SetTrigger(animatorParameterCallFrogs);
            callFrogs.Play();
        }

        if (bossEnemy.isSpawning)
        {
            bossFrogGreenSprite.SetActive(false);
            bossFrogRedSprite.SetActive(true);
            spriteChanged.Play();
        }
    }
}

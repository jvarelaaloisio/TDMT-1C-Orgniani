using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BossSpriteReplacer : MonoBehaviour
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
        if (bossFrogRedSprite.activeSelf && !bossEnemy.isTripleShooting && bossEnemy.attackNumber == 2)
        {
            bossFrogRedSprite.SetActive(false);
            bossFrogGreenSprite.SetActive(true);
            spriteChanged.Play();
        }

        else if (bossFrogGreenSprite.activeSelf && !bossEnemy.isExplodingShooting && bossEnemy.attackNumber == 1)
        {
            bossFrogGreenSprite.SetActive(false);
            bossFrogRedSprite.SetActive(true);
            spriteChanged.Play();
        }

        else if (!bossEnemy.isSpawning && bossEnemy.attackNumber == 3)
        {
            callFrogs.Play();
            animator.SetTrigger(animatorParameterCallFrogs);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deadSoundEffect;

    [SerializeField] private Gun _attack;
    [SerializeField] private HealthPoints _hurtAndDeath;

    private void Update()
    {
        if (_attack == null)
            Debug.LogError($"{name}: Gun in CharacterSound is null");

        if (_hurtAndDeath == null)
            Debug.LogError($"{name}: HealthPoints in CharacterSound is null");

        bool isShooting = _attack._isShooting;
        bool isHurt = _hurtAndDeath._isHurt;
        bool isDead = _hurtAndDeath._isDead;

        if (isShooting)
        {
            shootSoundEffect.Play();
        }

        if (isHurt)
        {
            hurtSoundEffect.Play();
        }

        if (isDead)
        {
            deadSoundEffect.Play();
        }

    }
}

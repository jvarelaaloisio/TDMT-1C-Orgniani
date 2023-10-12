using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deadSoundEffect;

    [SerializeField] private CharacterShooting _attack;
    [SerializeField] private HealthPoints _hurtAndDeath;

    private void OnEnable()
    {
        _attack.onShoot += HandleShoot;
    }

    private void OnDisable()
    {
        _attack.onShoot -= HandleShoot;
    }

    private void Update()
    {
        if (_attack == null)
            Debug.LogError($"{name}: Gun in CharacterSound is null");

        if (_hurtAndDeath == null)
            Debug.LogError($"{name}: HealthPoints in CharacterSound is null");

        bool isHurt = _hurtAndDeath._isHurt;
        bool isDead = _hurtAndDeath._isDead;

        if (isHurt)
        {
            hurtSoundEffect.Play();
        }

        if (isDead)
        {
            deadSoundEffect.Play();
        }

    }

    private void HandleShoot()
    {
        shootSoundEffect.Play();
    }
}

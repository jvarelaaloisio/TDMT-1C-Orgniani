using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deadSoundEffect;

    [SerializeField] private CharacterShooting _attack;
    [SerializeField] private HealthPoints _hurtAndDead;

    private void OnEnable()
    {
        _attack.onShoot += HandleShoot;
        _hurtAndDead.onHurt += HandleHurt;
        _hurtAndDead.onDead += HandleDead;
    }

    private void OnDisable()
    {
        _attack.onShoot -= HandleShoot;
        _hurtAndDead.onHurt -= HandleHurt;
        _hurtAndDead.onDead -= HandleDead;
    }

    private void Update()
    {
        if (_attack == null)
            Debug.LogError($"{name}: Gun in CharacterSound is null");

        if (_hurtAndDead == null)
            Debug.LogError($"{name}: HealthPoints in CharacterSound is null");
    }

    private void HandleShoot()
    {
        shootSoundEffect.Play();
    }

    private void HandleHurt()
    {
        hurtSoundEffect.Play();
    }

    private void HandleDead()
    {
        deadSoundEffect.Play();
    }
}

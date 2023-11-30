using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deadSoundEffect;

    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController hurtAndDead;

    private void OnEnable()
    {
        if (attack != null)
            attack.onShoot += HandleShoot;

        hurtAndDead.onHurt += HandleHurt;
        hurtAndDead.onDead += HandleDead;
    }

    private void OnDisable()
    {
        if (attack != null)
            attack.onShoot -= HandleShoot;

        hurtAndDead.onHurt -= HandleHurt;
        hurtAndDead.onDead -= HandleDead;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthController targetHP;

    [SerializeField] private List<GameObject> frogs;
    [SerializeField] private float spawnDelay = 1f;

    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private bool shouldShoot = false;
    [SerializeField] private bool shouldSpawn = false;

    private void OnEnable()
    {
        enemyHP.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        enemyHP.onDead -= HandleDeath;
    }

    private void Update()
    {
        //TODO: TP2 - Optimization - Should be event based --> ???
        if (targetHP.HP <= 0)
            return;

        if (!enabled) return;

        if (attack == null)
        {
            Debug.LogError($"{name}: CharacterShooting is null!");
            return;
        }

        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            BossShoot();
            StartCoroutine(SpawnFrogsCoroutine());
        }
    }

    //TODO: TP2 - Fix - Should be handled by the boss --> DONE
    private void BossShoot()
    {
        if (!attack.canShoot) return;

        Vector2 currentPosition = transform.position;

        Vector2 nextPosition = targetPosition.currentPosition;
        Vector2 nextPosition2 = targetPosition.currentPosition - new Vector2(3, 0);
        Vector2 nextPosition3 = targetPosition.currentPosition + new Vector2(3, 0);

        Vector2 directionToNextPos = nextPosition - currentPosition;
        Vector2 directionToNextPos2 = nextPosition2 - currentPosition;
        Vector2 directionToNextPos3 = nextPosition3 - currentPosition;

        StartCoroutine(attack.ShootSequence(directionToNextPos));
        StartCoroutine(attack.ShootSequence(directionToNextPos2));
        StartCoroutine(attack.ShootSequence(directionToNextPos3));
    }

    private IEnumerator SpawnFrogsCoroutine()
    {
        foreach (GameObject frog in frogs)
        {
            //TODO: TP2 - Optimization - Cache values/refs --> DONE ?? Check later if it can improve
            if (frog.TryGetComponent(out Collider2D collider))
                if (collider.enabled == true)
                    frog.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void HandleDeath()
    {
        if (TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        if (TryGetComponent(out CharacterMovement movement))
            movement.enabled = false;

        if (TryGetComponent(out CharacterShooting attack))
            attack.enabled = false;
    }
}

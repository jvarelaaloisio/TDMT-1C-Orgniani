using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthController targetHP;

    [SerializeField] private List<HealthController> frogs;
    [SerializeField] private float spawnDelay = 1f;

    [SerializeField] private float attackCooldown = 5f;

    //SHOULDNT BE SERIALIZED FIELD
    public bool isTripleShooting = true;
    public bool isExplodingShooting = false;

    private GameObject normalBulletPrefab;
    [SerializeField] private GameObject explodingBulletPrefab;

    public VoidDelegateType onAttackChange;

    private void OnEnable()
    {
        enemyHP.onDead += HandleDeath;
        normalBulletPrefab = attack.bulletPrefab;
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

        StartCoroutine(SpawnFrogsCoroutine());
        ExplodingShoot();

        if (!isTripleShooting) return;

        else
        {
            TripleShoot();
            StartCoroutine(AttackSequence());
        }
    }


    private Vector2 GetTargetLocation(Vector2 displacement)
    {
        Vector2 currentPosition = transform.position;

        Vector2 nextPosition = targetPosition.currentPosition + displacement;

        Vector2 directionToNextPos = nextPosition - currentPosition;

        return directionToNextPos;
    }

    //TODO: TP2 - Fix - Should be handled by the boss --> DONE
    private void TripleShoot()
    {
        if (!attack.canShoot) return;

        StartCoroutine(attack.ShootSequence(GetTargetLocation(new Vector2(0, 0))));
        StartCoroutine(attack.ShootSequence(GetTargetLocation(new Vector2(3, 0))));
        StartCoroutine(attack.ShootSequence(GetTargetLocation(new Vector2(-3, 0))));
    }

    private void ExplodingShoot()
    {
        if (!isExplodingShooting) return;
        attack.Shoot(GetTargetLocation(new Vector2 (0,0)));
    }

    private IEnumerator SpawnFrogsCoroutine()
    {
        foreach (HealthController frog in frogs)
        {
            //TODO: TP2 - Optimization - Cache values/refs --> DONE
            if (frog.HP > 0)
            {
                frog.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(attackCooldown);

        if (onAttackChange != null) onAttackChange();
        isTripleShooting = false;
        attack.bulletPrefab = explodingBulletPrefab;
        isExplodingShooting = true;

        yield return new WaitForSeconds(attackCooldown);

        if (onAttackChange != null) onAttackChange();
        isExplodingShooting = false;
        attack.bulletPrefab = normalBulletPrefab;
        isTripleShooting = true;

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

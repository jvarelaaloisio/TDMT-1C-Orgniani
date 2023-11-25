using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager;

    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthController targetHP;

    [SerializeField] private List<HealthController> frogs;
    [SerializeField] private float spawnDelay = 1f;

    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private float betweenAttacksCooldown = 2f;

    public bool isTripleShooting = true;
    public bool isExplodingShooting = false;
    public bool isSpawning = false;

    public int attackNumber = 1;

    private GameObject normalBulletPrefab;
    [SerializeField] private GameObject explodingBulletPrefab;

    public VoidDelegateType onAttackChange;

    private void OnEnable()
    {
        enemyHP.onDead += HandleDeath;
        enemiesManager.onDamageAll += KillAllActiveFrogs;
        normalBulletPrefab = attack.bulletPrefab;
    }

    private void OnDisable()
    {
        enemyHP.onDead -= HandleDeath;
        enemiesManager.onDamageAll -= KillAllActiveFrogs;
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
            StartCoroutine(SpawnFrogsCoroutine());
            ExplodingShoot();

            if (!isTripleShooting) return;

            else
            {
                TripleShoot();
                StartCoroutine(AttackSequence());
            }
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
        if (!isSpawning) yield break;

        foreach (HealthController frog in frogs)
        {
            if (!isSpawning) yield break;

            //TODO: TP2 - Optimization - Cache values/refs --> DONE
            if (frog.HP > 0 )
            {
                frog.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(attackCooldown);

        isTripleShooting = false;

        yield return new WaitForSeconds(betweenAttacksCooldown);

        attackNumber = 2;
        if (onAttackChange != null) onAttackChange();
        attack.bulletPrefab = explodingBulletPrefab;
        isExplodingShooting = true;

        yield return new WaitForSeconds(attackCooldown);

        isExplodingShooting = false;

        yield return new WaitForSeconds(betweenAttacksCooldown);

        attackNumber = 3;
        if (onAttackChange != null) onAttackChange();
        isSpawning = true;

        yield return new WaitForSeconds(attackCooldown);

        isSpawning = false;

        yield return new WaitForSeconds(betweenAttacksCooldown);

        attackNumber = 1;
        if (onAttackChange != null) onAttackChange();
        attack.bulletPrefab = normalBulletPrefab;
        isTripleShooting = true;
    }

    private void HandleDeath()
    {
        if (TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        attack.enabled = false;

        KillAllActiveFrogs();

        enabled = false;
    }

    private void KillAllActiveFrogs()
    {
        foreach (HealthController frog in frogs)
        {
            if(frog.gameObject.activeSelf)
            {
                frog.TakeDamage(frog.HP);
            }
        }
    }
}

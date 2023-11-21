using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] public HealthModel model;
    [SerializeField] public int maxHP = 100;
    [SerializeField] public int HP = 100;

    [SerializeField] private DamageHandler damageHandler;

    [SerializeField] private bool shouldDestroyOnDeath;
    [SerializeField] private bool isEnemy;

    [SerializeField] private float hurtCooldown = 1f;
    private float currentTime = 0;
    private bool canHurt = true;

    [SerializeField] private float deactivateDelay = 2f;

    public VoidDelegateType onHurt;
    public VoidDelegateType onDead;

    //private void Awake()
    //{
    //    SetHpToMaxHp();
    //}

    [ContextMenu("Reset HP to maxHP")]
    private void SetHpToMaxHp()
    {
        HP = model.maxHP;
    }

    public DamageHandler DamageHandler
    {
        get
        {
            return damageHandler;
        }

        set
        {
            damageHandler = value;
        }
    }

    private void Update()
    {
        if (!canHurt)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= hurtCooldown)
            {
                canHurt = true;
                currentTime = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!canHurt) return;

        if (isEnemy && damage == 1) return;

        HP = damageHandler.HandleDamage(HP, damage);

        if(onHurt != null)
        {
            onHurt();
        }

        if (HP <= 0)
        {
            Die();
        }

        canHurt = false;
    }

    public void Resurrect()
    {
        HP = maxHP;
    }

    private void Die()
    {
        if (onDead != null)
        {
            onDead();
        }

        if (shouldDestroyOnDeath)
        {
            Destroy(gameObject);
        }

        else
        {
            //TODO: TP2 - Fix - This should be handled by other scripts, like the enemy scripts, by subscribing to the onDead event. --> DONE

            if (isEnemy)
                StartCoroutine(Deactivate());
        }
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deactivateDelay);

        gameObject.SetActive(false);
    }
}
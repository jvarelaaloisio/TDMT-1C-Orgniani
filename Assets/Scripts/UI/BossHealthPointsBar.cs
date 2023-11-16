using UnityEngine;
using UnityEngine.UI;

public class BossHealthPointsBar : MonoBehaviour
{
    //TODO: TP2 - Fix - Use Image with type "Sliced" and set the fill amount to bossHP.HP/bossHP.MaxHP --> DONE
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthController bossHP;

    private void OnEnable()
    {
        bossHP.onHurt += HandleHealthBar;
    }

    private void OnDisable()
    {
        bossHP.onHurt -= HandleHealthBar;
    }

    private void HandleHealthBar()
    {
        //TODO: TP2 - Optimization - Should be event based (BossHP.OnHurt) --> DONE
        healthBar.fillAmount = 1.0f * bossHP.HP / bossHP.maxHP;
    }
}

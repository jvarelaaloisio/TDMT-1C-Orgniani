using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthPointsBar : MonoBehaviour
{
    //TODO: TP2 - Fix - Use Image with type "Sliced" and set the fill amount to bossHP.HP/bossHP.MaxHP
    [SerializeField] private Slider slider;
    [SerializeField] private HealthController bossHP;


    private void Start()
    {
        slider.maxValue = bossHP.maxHP;
    }

    private void Update()
    {
        //TODO: TP2 - Optimization - Should be event based (BossHP.OnHurt)
        slider.value = bossHP.HP;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthPointsBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthPoints bossHP;


    private void Start()
    {
        slider.maxValue = bossHP.maxHP;
    }

    private void Update()
    {
        slider.value = bossHP.HP;
    }
}

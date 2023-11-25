using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: TP2 - Fix - Unify with BossHealthBar --> ASKED TO IGNORE BY TEACHER
public class HealthPointsBar : MonoBehaviour
{
    [SerializeField] private HealthController playerHP;

    [SerializeField] private GameObject heart;
    [SerializeField] private List<Image> hearts;

    private void OnEnable()
    {
        playerHP.onHurt += HandleHealthBar;
    }

    private void OnDisable()
    {
        playerHP.onHurt -= HandleHealthBar;
    }

    private void Start()
    {
        for (int i = 0; i < playerHP.maxHP; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

    private void HandleHealthBar()
    {
        int heartFill = playerHP.HP;

        foreach(Image i in hearts)
        {
            i.fillAmount = heartFill;
            heartFill -= 1;
        }
    }
}



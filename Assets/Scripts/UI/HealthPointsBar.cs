using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsBar : MonoBehaviour
{
    //[SerializeField] private Image bar;

    [SerializeField] private HealthPoints playerHP;

    [SerializeField] private GameObject heart;
    [SerializeField] private List<Image> hearts;

    private void Start()
    {
        for (int i = 0; i < playerHP.maxHP; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

    private void Update()
    {
        //bar.fillAmount = 1.0f * healthPoints.HP / healthPoints.maxHP;
        int heartFill = playerHP.HP;

        foreach(Image i in hearts)
        {
            i.fillAmount = heartFill;
            heartFill -= 1;
        }
    }
}



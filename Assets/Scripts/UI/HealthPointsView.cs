using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPointsView : MonoBehaviour
{
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private TMP_Text HPValueText;

    private void Update()
    {
        if (HPValueText)
        {
            HPValueText.text = healthPoints.HP.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health/Model", fileName = "_healthModel")]
public class HealthModel : ScriptableObject
{
    [SerializeField] public int maxHP = 100;
}

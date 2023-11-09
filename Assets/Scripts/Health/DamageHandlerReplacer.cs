using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandlerReplacer : MonoBehaviour
{
    [SerializeField] DamageHandler replacement;
    [SerializeField] HealthController playerHP;

    public void ReplaceDamageHandler()
    {
        var temp = playerHP.damageHandler;
        playerHP.damageHandler = replacement;
        replacement = temp;
    }
}

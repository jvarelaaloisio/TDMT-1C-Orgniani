using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health/Invincible Damage Handler", fileName = "DH_")]
public class InvincibleDamageHandler : DamageHandler
{
    public override int HandleDamage(int currentHP, int _)
    {
        return currentHP;
    }
}

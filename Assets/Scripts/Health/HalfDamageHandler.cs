using UnityEngine;

[CreateAssetMenu(menuName = "Health/Half Damage Handler", fileName = "DH_")]
public class HalfDamageHandler : DamageHandler
{
    public override int HandleDamage(int currentHP, int _)
    {
        return currentHP;
    }
}

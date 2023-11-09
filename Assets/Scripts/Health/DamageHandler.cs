using UnityEngine;

[CreateAssetMenu(menuName = "Health/Damage Handler", fileName = "DH_")]
public class DamageHandler : ScriptableObject
{
    public virtual int HandleDamage(int currentHP, int damage)
    {
        var newHealthPoints = currentHP - damage;
        return newHealthPoints;
    }
}

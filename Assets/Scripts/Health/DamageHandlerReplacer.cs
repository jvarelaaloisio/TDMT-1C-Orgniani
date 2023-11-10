using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health/Damage Handler Replacer", fileName = "HR_")]
public class DamageHandlerReplacer : ScriptableObject
{
    [SerializeField] DamageHandler replacement;
    [SerializeField] private string tagToSearch = "Player";

    public void ReplaceDamageHandler()
    {
        var target = GameObject.FindGameObjectWithTag(tagToSearch);

        if(target.TryGetComponent(out HealthController controller))
        {
            var temp = controller.DamageHandler;
            controller.DamageHandler = replacement;
            replacement = temp;
        }
    }
}

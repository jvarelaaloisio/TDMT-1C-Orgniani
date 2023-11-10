using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Movement/Speed Handler Replacer", fileName = "SR_")]
public class SpeedHandlerReplacer : ScriptableObject
{
    [SerializeField] SpeedHandler replacement;
    [SerializeField] private string tagToSearch = "Player";

    public void ReplaceSpeedHandler()
    {
        var target = GameObject.FindGameObjectWithTag(tagToSearch);

        if (target.TryGetComponent(out CharacterMovement controller))
        {
            var temp = controller.SpeedHandler;
            controller.SpeedHandler = replacement;
            replacement = temp;
        }
    }
}

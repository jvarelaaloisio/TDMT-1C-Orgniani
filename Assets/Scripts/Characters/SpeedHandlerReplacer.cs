using UnityEngine;

[CreateAssetMenu(menuName = "Character Movement/Speed Handler Replacer", fileName = "SR_")]
public class SpeedHandlerReplacer : ScriptableObject
{
    [SerializeField] SpeedHandler speedMultiplier;
    [SerializeField] private string tagToSearch = "Player";

    private SpeedHandler replacement;

    private void OnEnable()
    {
        replacement = speedMultiplier;
    }

    public void ReplaceSpeedHandler()
    {
        var target = GameObject.FindGameObjectWithTag(tagToSearch);

        if (target.TryGetComponent(out CharacterMovement controller))
        {
            if (replacement == controller.SpeedHandler)
            {
                replacement = speedMultiplier;
            }

            var temp = controller.SpeedHandler;

            controller.SpeedHandler = replacement;
            replacement = temp;
        }
    }
}

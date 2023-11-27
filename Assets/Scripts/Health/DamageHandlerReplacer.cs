using UnityEngine;

[CreateAssetMenu(menuName = "Health/Damage Handler Replacer", fileName = "HR_")]
public class DamageHandlerReplacer : ScriptableObject
{
    [SerializeField] private DamageHandler invincibleHandler;
    [SerializeField] private string tagToSearch = "Player";

    private DamageHandler replacement;

    private void OnEnable()
    {
        replacement = invincibleHandler;
    }

    public void ReplaceDamageHandler()
    {
        var target = GameObject.FindGameObjectWithTag(tagToSearch);

        if(target.TryGetComponent(out HealthController controller))
        {
            if (replacement == controller.DamageHandler)
            {
                replacement = invincibleHandler;
            }

            var temp = controller.DamageHandler;

            controller.DamageHandler = replacement;
            replacement = temp;
        }
    }
}

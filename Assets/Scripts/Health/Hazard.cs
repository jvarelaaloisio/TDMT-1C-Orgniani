using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject playerGameObject = col.gameObject;

        //TODO: TP2 - Optimization - TryGetComponent --> DONE
        if(playerGameObject.TryGetComponent(out HealthController playerHP))
            playerHP.TakeDamage(damage);
    }
}
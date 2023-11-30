using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnParticleCollision()
    {
        if(TryGetComponent(out HealthController playerHP))
        {
            playerHP.TakeDamage(1);
        }
    }
}

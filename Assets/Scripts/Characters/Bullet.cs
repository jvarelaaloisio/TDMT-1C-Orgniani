using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlesPrefab;

    private void OnDestroy()
    {
        if(deathParticlesPrefab)
        {
            Instantiate(deathParticlesPrefab, 
                        transform.position, 
                         transform.rotation);
        }
    }
}

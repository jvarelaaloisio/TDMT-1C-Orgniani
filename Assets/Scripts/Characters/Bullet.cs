using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlesPrefab;
    [SerializeField] private bool shouldDestroyOnRoute = false;
    [SerializeField] private float destroyDelay = 1f;

    private void Update()
    {
        if(shouldDestroyOnRoute)
            Destroy(gameObject, destroyDelay);
    }

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

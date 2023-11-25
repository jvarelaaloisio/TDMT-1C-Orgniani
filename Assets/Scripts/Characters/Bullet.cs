using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlesPrefab;
    [SerializeField] private bool shouldDestroyOnRoute = false;
    [SerializeField] private float destroyDelay = 1f;

    private void Update()
    {
        if (shouldDestroyOnRoute)
            StartCoroutine(DestroyOnRoute());
    }

    private void OnTriggerEnter2D(Collider2D coL)
    {
        InstantiateParticles();
    }

    private IEnumerator DestroyOnRoute()
    {
        yield return new WaitForSeconds(destroyDelay);

        InstantiateParticles();
        Destroy(gameObject);
    }

    private void InstantiateParticles()
    {
        if (deathParticlesPrefab)
        {
            Instantiate(deathParticlesPrefab,
                        transform.position,
                         transform.rotation);
        }
    }
}


using System.Collections;
using UnityEngine;

public delegate void VoidDelegateType();

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float shootCooldown = 1f;
    public bool canShoot = true;

    [SerializeField] private float shootDelay = 1f;

    [SerializeField] private float bulletDelay = 0.3f;
    [SerializeField] private int bulletAmount = 1;

    public VoidDelegateType onShoot;
    
    [ContextMenu(itemName: "Shoot")]

    public void Shoot(Vector2 bulletDirection)
    {
        if (!canShoot) return;

        if(TryGetComponent(out CharacterShooting characterShooting))
            if (characterShooting.enabled == false)
                return;

        if (!bulletPrefab)
        {
            Debug.LogError($"{name}: bulletPrefab is null");
        }

        if (!spawnPoint)
        {
            Debug.LogError($"{name}: spawnPoint is null");
        }

        StartCoroutine(ShootSequence(bulletDirection));
    }

    //TODO: TP2 - Fix - Should be handled by the boss --> ASK
    public void BossShoot(Vector2 bulletDirection, Vector2 bulletDirection2, Vector2 bulletDirection3)
    {
        if (!canShoot) return;

        if (!bulletPrefab)
        {
            Debug.LogError($"{name}: bulletPrefab is null");
        }

        if (!spawnPoint)
        {
            Debug.LogError($"{name}: spawnPoint is null");
        }

        StartCoroutine(ShootSequence(bulletDirection));
        StartCoroutine(ShootSequence(bulletDirection2));
        StartCoroutine(ShootSequence(bulletDirection3));
    }

    private IEnumerator ShootSequence(Vector2 bulletDirection)
    {
        canShoot = false;

        if (onShoot != null)
        {
            onShoot();
        }

        yield return new WaitForSeconds(shootDelay);

        for (int i = 0; i < bulletAmount; i++)
        {
            var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            var bulletMovement = bullet.GetComponent<CharacterMovement>();

            bulletMovement.SetDirection(bulletDirection.normalized);

            yield return new WaitForSeconds(bulletDelay);
        }

        //TODO: TP2 - Could be a coroutine/Invoke --> DONE
        yield return new WaitForSeconds(shootCooldown);

        canShoot = true;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public delegate void VoidDelegateType();
public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float shootCooldown = 1f;
    private float currentTime = 0;
    public bool canShoot = true;

    [SerializeField] private float shootDelay = 1f;

    [SerializeField] private float bulletDelay = 0.3f;
    [SerializeField] private int bulletAmount = 1;

    public VoidDelegateType onShoot;
    
    [ContextMenu(itemName: "Shoot")]

    private void Update()
    {
        if (!canShoot)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= shootCooldown)
            {
                canShoot = true;
                currentTime = 0;
            }

        }
    }

    public void Shoot(Vector2 bulletDirection)
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
    }

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
    }
}
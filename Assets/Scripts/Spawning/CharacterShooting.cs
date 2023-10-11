using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{ 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float shootCooldown = 1f;
    private float currentTime = 0;
    public bool canShoot = true;

    [SerializeField] private float animationCooldown = 0.1f;
    public bool _isShooting = false;

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

    private IEnumerator ShootSequence(Vector2 bulletDirection)
    {
        canShoot = false;

        _isShooting = true;

        yield return new WaitForSeconds(animationCooldown);

        var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletMovement = bullet.GetComponent<CharacterMovement>();

        bulletMovement.SetDirection(bulletDirection.normalized);

        _isShooting = false;
    }
}
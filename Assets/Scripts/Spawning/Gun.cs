using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
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

            if (currentTime >= animationCooldown)
            {
                _isShooting = false;
            }
        }
    }

    public void Shoot(Vector2 bulletDirection)
    {
        if (!canShoot) return;

        if (bulletPrefab == null) return;

        _isShooting = true;

        var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletMovement = bullet.GetComponent<CharacterMovement>();

        bulletMovement.SetDirection(bulletDirection.normalized);
        canShoot = false;

    }

}
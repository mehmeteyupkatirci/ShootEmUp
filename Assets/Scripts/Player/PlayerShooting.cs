using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f; // İki ateş arasında geçen süre
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }

   void Fire()
    {
        // bulletPrefab'ın geçerli olup olmadığını kontrol et
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Bullet prefab is missing!");
        }
    }
}

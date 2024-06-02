using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePoint; // İlk ateş noktası
    public GameObject bulletPrefab;
    public int additionalProjectiles = 0; // Ekstra ateş edilecek mermi sayısı
    public float spreadAngle = 10f; // Mermilerin yayılma açısı

    private bool isShooting = false;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        StartShooting();
    }

    public void AddProjectile()
    {
        additionalProjectiles++;
    }

    public void IncreaseFireRate(float amount)
    {
        // Ateş etme hızını arttır
    }

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(0.40f); // Ateş etme hızını ayarlayın
        }
    }

    private void Shoot()
    {
        // Ana ateş noktası
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Ek mermiler
        for (int i = 1; i <= additionalProjectiles; i++)
        {
            float angle = i * spreadAngle; // Yayılma açısını ayarla
            Quaternion rotationLeft = Quaternion.Euler(new Vector3(0, 0, firePoint.rotation.eulerAngles.z - angle));
            Quaternion rotationRight = Quaternion.Euler(new Vector3(0, 0, firePoint.rotation.eulerAngles.z + angle));

            Instantiate(bulletPrefab, firePoint.position, rotationLeft);
            Instantiate(bulletPrefab, firePoint.position, rotationRight);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(3); // Enemy ile çarpıştığında 3 hasar alır
            }

            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(enemyHealth.health); // Enemy'yi yok eder
            }
        }
    }
}

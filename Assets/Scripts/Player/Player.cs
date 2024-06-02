using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePoint; // İlk ateş noktası
    public GameObject bulletPrefab;
    public int additionalProjectiles = 0; // Ekstra ateş edilecek mermi sayısı
    public float spreadAngle = 10f; // Mermilerin yayılma açısı
    public float shootDelay = 0.4f; // Ateş etme hızı
    private float minShootDelay = 0.1f; // Minimum ateş etme hızı

    private bool isShooting = false;

    private void Start()
    {
        StartShooting();
    }

    public void AddProjectile()
    {
        additionalProjectiles++;
    }

    public void IncreaseFireRate(float amount)
    {
        if (shootDelay > minShootDelay)
        {
            shootDelay = Mathf.Max(shootDelay - amount, minShootDelay);
        }
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
            yield return new WaitForSeconds(shootDelay);
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
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp powerUp = collision.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                powerUp.ApplyPowerUp(this);
            }
        }
    }
}

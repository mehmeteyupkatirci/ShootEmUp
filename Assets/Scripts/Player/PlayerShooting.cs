using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // İlk ateş noktası
    public GameObject bulletPrefab;
    public int additionalProjectiles = 0; // Ekstra ateş edilecek mermi sayısı
    public float spreadAngle = 10f; // Mermilerin yayılma açısı
    public float fireRate = 0.3f; // Ateş etme hızı
    public int damage = 1; // Mermilerin verdiği hasar

    private bool isShooting = false;

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate); // Ateş etme hızını ayarlayın
        }
    }

    private void Shoot()
    {
        // Ana ateş noktası
        ShootBullet(firePoint.position, firePoint.rotation);

        // Ek mermiler
        for (int i = 1; i <= additionalProjectiles; i++)
        {
            float angle = i * spreadAngle; // Yayılma açısını ayarla
            Quaternion rotationLeft = Quaternion.Euler(new Vector3(0, 0, firePoint.rotation.eulerAngles.z - angle));
            Quaternion rotationRight = Quaternion.Euler(new Vector3(0, 0, firePoint.rotation.eulerAngles.z + angle));

            ShootBullet(firePoint.position, rotationLeft);
            ShootBullet(firePoint.position, rotationRight);
        }
    }

    private void ShootBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDamage(damage); // Merminin hasarını ayarla
        }
    }

    public void AddProjectile()
    {
        additionalProjectiles++;
    }

    public void IncreaseFireRate(float amount)
    {
        fireRate = Mathf.Max(0.1f, fireRate - amount); // Ateş etme hızını artır
    }
}

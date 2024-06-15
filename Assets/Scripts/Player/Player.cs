using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Transform firePoint; // İlk ateş noktası
    public GameObject bulletPrefab;
    public int additionalProjectiles = 0; // Ekstra ateş edilecek mermi sayısı
    public float spreadAngle = 10f; // Mermilerin yayılma açısı
    public int health = 10; // Oyuncunun can puanı
    public float fireRate = 0.3f; // Ateş etme hızı
    public int exp = 0; // Toplanan EXP miktarı
    public int level = 1; // Oyuncunun seviyesi
    public int expToNextLevel = 100; // İlk seviyeye geçiş için gereken EXP miktarı

    public Slider expSlider; // Level Bar'ı temsil eden Slider
    public TMP_Text levelText; // Level Text bileşeni

    private bool isShooting = false;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        StartShooting();
        UpdateHUD();
    }

    public void AddProjectile()
    {
        additionalProjectiles++;
    }

    public void IncreaseFireRate(float amount)
    {
        fireRate = Mathf.Max(0.1f, fireRate - amount); // Ateş etme hızını arttır
    }

    public void IncreaseHealth(int amount)
    {
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(amount);
        }
    }

    public void AddEXP(int amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            LevelUp();
        }
        UpdateHUD();
    }

    private void LevelUp()
    {
        level++;
        exp -= expToNextLevel;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.5f); // Gelecek seviye için gereken EXP miktarını artır

        // Seviye atlama durumunda yapılacak işlemler (örneğin, sağlık artırma, ateş hızı artırma, vb.)
        health += 5; // Örneğin, sağlık artırma
        UpdateHUD();
        Debug.Log("Level Up! New Level: " + level);
    }

    private void UpdateHUD()
    {
        if (expSlider != null)
        {
            expSlider.maxValue = expToNextLevel;
            expSlider.value = exp;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
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
            yield return new WaitForSeconds(fireRate); // Ateş etme hızını ayarlayın
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

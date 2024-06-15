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
    public float fireRate = 0.3f; // Ateş etme hızı
    public int exp = 0; // Toplanan EXP miktarı
    public int level = 1; // Oyuncunun seviyesi
    public int expToNextLevel = 100; // İlk seviyeye geçiş için gereken EXP miktarı
    public int damage = 1; // Oyuncunun verdiği hasar
    public int maxHealth = 10; // Oyuncunun maksimum can puanı
    public float speed = 5f; // Oyuncunun hareket hızı

    public Slider expSlider; // Level Bar'ı temsil eden Slider
    public TMP_Text levelText; // Level Text bileşeni

    private bool isShooting = false;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.SetMaxHealth(maxHealth);
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

        // Seviye atlama durumunda yapılacak işlemler
        IncreaseStats();

        UpdateHUD();
        Debug.Log("Level Up! New Level: " + level);
    }

    private void IncreaseStats()
    {
        damage += 1; // Hasarı artır
        maxHealth += 1; // Maksimum canı artır
        speed += 0.5f; // Hızı artır
        //health = maxHealth; // Sağlığı maksimum seviyeye getir
        playerHealth.SetMaxHealth(maxHealth);
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
}

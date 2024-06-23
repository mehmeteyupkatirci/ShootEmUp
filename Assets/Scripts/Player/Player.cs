using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public event Action<int> OnLevelUp; // Seviye atlama olayı

    public int exp = 0; // Toplanan EXP miktarı
    public int level = 1; // Oyuncunun seviyesi
    public int expToNextLevel = 100; // İlk seviyeye geçiş için gereken EXP miktarı
    public int maxHealth = 10; // Oyuncunun maksimum can puanı
    public float speed = 5f; // Oyuncunun hareket hızı

    public Slider expSlider; // Level Bar'ı temsil eden Slider
    public TMP_Text levelText; // Level Text bileşeni

    private PlayerHealth playerHealth;
    private PlayerShooting playerShooting;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerShooting = GetComponent<PlayerShooting>();
        playerHealth.SetMaxHealth(maxHealth);
        playerShooting.StartShooting();
        UpdateHUD();
    }

    public void IncreaseHealth(int amount)
    {
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(amount);
        }
    }

    public void IncreaseFireRate(float amount)
    {
        if (playerShooting != null)
        {
            playerShooting.IncreaseFireRate(amount);
        }
    }

    public void AddProjectile()
    {
        if (playerShooting != null)
        {
            playerShooting.AddProjectile();
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
        OnLevelUp?.Invoke(level); // Seviye atlama olayını tetikleyin
        UpdateHUD();
        Debug.Log("Level Up! New Level: " + level);
    }

    private void IncreaseStats()
    {
        playerShooting.damage += 1; // Hasarı artır
        maxHealth += 1; // Maksimum canı artır
        speed += 0.5f; // Hızı artır
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
}

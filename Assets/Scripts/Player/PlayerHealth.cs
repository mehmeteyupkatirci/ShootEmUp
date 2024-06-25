using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private TextMeshProUGUI healthText; // Canı gösterecek TextMeshPro öğesi
    private GameObject gameOverPanel; // Game Over Panel referansı
    private TextMeshProUGUI gameOverScoreText; // Game Over Panelindeki skor göstergesi

    private void Awake()
    {
        // Sahne içinde Canvas altındaki referansları bul
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverScoreText = GameObject.Find("GameOverScoreText").GetComponent<TextMeshProUGUI>();

        // GameOverPanel başlangıçta kapalı olmalı
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth; // Maksimum sağlığı güncellediğinizde, mevcut sağlığı da maksimum yapın
        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0); // Canın negatif olmamasını sağla
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1); // Hasar miktarı buradan ayarlanabilr
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    private void Die()
    {
        // Skoru güncelle
        if (gameOverScoreText != null)
        {
            int finalScore = ScoreManager.Instance.GetScore(); // Skoru ScoreManager'dan al
            gameOverScoreText.text = "Score: " + finalScore.ToString();
        }

        // Game Over Panel'i göster
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Oyunu durdur
        }
    }
}

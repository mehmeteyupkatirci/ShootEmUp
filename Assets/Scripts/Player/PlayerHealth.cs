using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Oyunu yeniden başlatmak için
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public TextMeshProUGUI healthText; // Canı gösterecek TextMeshPro öğesi

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
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
        // Oyunu yeniden başlat
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForEndOfFrame(); // Bir frame bekleyin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

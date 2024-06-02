using UnityEngine;
using UnityEngine.SceneManagement; // Oyunu yeniden başlatmak için

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Oyunu yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
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
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForEndOfFrame(); // Bir frame bekleyin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

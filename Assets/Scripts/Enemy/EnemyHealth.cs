using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public int scoreValue = 10; // Bu düşmanın verdiği puan

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyPowerUpDrop powerUpDrop = GetComponent<EnemyPowerUpDrop>();
        if (powerUpDrop != null)
        {
            powerUpDrop.DropPowerUp();
        }
        
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1); // Mermi her vurduğunda 1 hasar verir
            Destroy(collision.gameObject); // Mermi yok edilir
        }
    }
}

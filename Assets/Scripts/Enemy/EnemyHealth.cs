using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 3;
    public int scoreValue = 10; // Bu düşmanın verdiği puan
    public GameObject expOrbPrefab; // EXP Orb prefab'ını buraya bağlayın

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void LevelUp(int level)
    {
        maxHealth += level * 2; // Seviye başına 2 sağlık puanı ekleyin
        currentHealth = maxHealth; // Sağlığı maksimum yap
    }

    private void Die()
    {
        EnemyPowerUpDrop powerUpDrop = GetComponent<EnemyPowerUpDrop>();
        if (powerUpDrop != null)
        {
            powerUpDrop.DropPowerUp();
        }

        // EXP Orbi bırak
        Instantiate(expOrbPrefab, transform.position, Quaternion.identity);

        ScoreManager.Instance.AddScore(scoreValue);
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

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10; // Düşmanın can puanı

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
        GetComponent<EnemyPowerUpDrop>().DropPowerUp();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Oyuncuya zarar ver
            // Player scriptinde bir zarar verme fonksiyonu çağırabilirsiniz
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1); // Mermi her vurduğunda 1 hasar verir
            Destroy(collision.gameObject); // Mermi yok edilir
        }
    }
}

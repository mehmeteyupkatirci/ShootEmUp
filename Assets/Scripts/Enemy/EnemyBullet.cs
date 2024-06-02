using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1; // Merminin verdiği hasar
    private Vector2 moveDirection;

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        if (player != null)
        {
            Vector2 target = player.position; // Oyuncunun konumunu hedef olarak belirle
            moveDirection = (target - (Vector2)transform.position).normalized * speed; // Hedef yönünü belirle ve normalleştir
        }
        else
        {
            moveDirection = Vector2.down * speed; // Eğer oyuncu yoksa aşağı doğru git
        }
    }

    void Update()
    {
        // Belirlenen yöne doğru hareket et
        transform.Translate(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Hasar ver
            }
            Destroy(gameObject); // Mermiyi yok et
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Mermi ekrandan çıktığında yok et
    }
}

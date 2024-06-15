using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Merminin hareket hızı
    private int damage = 1; // Merminin verdiği hasar

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Mermi yok edilir
        }
    }

    private void Update()
    {
        // Mermiyi ileriye doğru hareket ettir
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

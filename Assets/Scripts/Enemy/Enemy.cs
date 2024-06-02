using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Düşmanın hareket hızı
    private Vector2 direction; // Düşmanın hareket yönü
    private Rigidbody2D rb;

    public int health = 10; // Düşmanın can puanı

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = direction * speed;

        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0 || pos.x > 1)
        {
            direction.x = -direction.x;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x),
                transform.position.y,
                transform.position.z
            );
        }

        if (pos.y < 0 || pos.y > 1)
        {
            direction.y = -direction.y;
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Clamp(transform.position.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y),
                transform.position.z
            );
        }
    }

    private void SetRandomDirection()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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

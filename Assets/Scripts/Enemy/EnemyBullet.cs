using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    private int damage;
    private Vector2 moveDirection;

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            Vector2 target = player.position;
            moveDirection = (target - (Vector2)transform.position).normalized * speed;
        }
        else
        {
            moveDirection = Vector2.down * speed;
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

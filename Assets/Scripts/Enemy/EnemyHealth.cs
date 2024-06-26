// using UnityEngine;

// public class EnemyHealth : MonoBehaviour
// {
//     private EnemyModel enemyModel;
//     public int scoreValue = 10; // Bu düşmanın verdiği puan
//     public GameObject expOrbPrefab; // EXP Orb prefab'ını buraya bağlayın

//     public void SetEnemyModel(EnemyModel model)
//     {
//         enemyModel = model;
//     }

//     public void TakeDamage(int damage)
//     {
//         enemyModel.Health -= damage;
//         if (enemyModel.Health <= 0)
//         {
//             Die();
//         }
//     }

//     private void Die()
//     {
       
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Bullet"))
//         {
//             TakeDamage(1); // Mermi her vurduğunda 1 hasar verir
//             Destroy(collision.gameObject); // Mermi yok edilir
//         }
//     }
// }

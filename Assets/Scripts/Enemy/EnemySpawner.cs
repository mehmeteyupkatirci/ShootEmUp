using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düşman prefab'ı
    public float spawnInterval = 2f; // Düşmanların oluşma süresi
    public float xMin, xMax; // X eksenindeki minimum ve maksimum değerler

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Rastgele bir X pozisyonu seç
        float randomX = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}

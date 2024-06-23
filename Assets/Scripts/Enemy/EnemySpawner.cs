using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Düşman prefab'larının listesi
    public float spawnInterval = 2f; // Düşmanların oluşma süresi
    public float xMin, xMax; // X eksenindeki minimum ve maksimum değerler

    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnLevelUp += HandleLevelUp;
        }

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

        // Rastgele bir düşman prefab'ı seç
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    private void HandleLevelUp(int newLevel)
    {
        // Spawn interval'ı seviye ile birlikte azaltın
        spawnInterval = Mathf.Max(0.5f, 2f - newLevel * 0.2f);
    }
}

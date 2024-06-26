using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public GameObject[] enemyPrefabs;
    private float spawnInterval = 4f;
    public float xMin, xMax;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        float randomX = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    private void HandleLevelUp(int newLevel)
    {
        spawnInterval = Mathf.Max(0.5f, 4f - newLevel * 0.2f);

        // Tüm mevcut düşmanları güçlendir
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().LevelUpEnemy(newLevel);
        }
    }

    public void IncreaseEnemyStrength(int level)
    {
        // Bu metot, yeni spawn olacak düşmanların gücünü artırmak için kullanılabilir
    }
}

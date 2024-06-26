using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public EnemyStats enemyStats { get; private set; }
    private EnemyModel enemyModel;

    // private EnemyHealth enemyHealth;
    private EnemyShooter enemyShooter;
    private EnemyMovement enemyMovement;

    public enum EnemyType
    {
        Basic,
        Strong,
        Fast,
        Boss
    }
    
    private void Start()
    {
        // EnemyDatabase'den ilgili EnemyStats nesnesini al
        EnemyStats enemyStats = EnemyDatabase.GetEnemyStats(enemyType);
        // EnemyModel'i oluştur ve EnemyStats ile başlat
        enemyModel = new EnemyModel(enemyStats);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            enemyModel.TakeDamage(1); // Düşmana 1 hasar ver
            Destroy(collision.gameObject); // Mermiyi yok et
        }
    }

    public void LevelUpEnemy(int level)
    {
        enemyModel.LevelUp(level);
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public EnemyModel enemyModel;
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
        // EnemyDatabase'den ilgili EnemyModel nesnesini al
        EnemyModel enemyStats = EnemyDatabase.GetEnemy(enemyType);
        // EnemyModel'i oluştur ve başlat
        enemyModel = new EnemyModel(
            enemyStats.Health, 
            enemyStats.AttackDamage, 
            enemyStats.HitDamage, 
            enemyStats.Speed, 
            enemyStats.PowerUpDropChance, 
            enemyStats.AttackSpeed, 
            enemyStats.Score
        );

        // Örnek olarak enemyMovement ve enemyShooter gibi bileşenleri de başlatmak gerekebilir
        // enemyMovement = GetComponent<EnemyMovement>();
        // enemyShooter = GetComponent<EnemyShooter>();
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

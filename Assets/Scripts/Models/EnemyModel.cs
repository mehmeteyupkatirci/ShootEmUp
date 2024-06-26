using System;
public class EnemyModel
{
    public event Action<int> OnLevelUp; // Level up olduğunda çağrılacak event

    public int Health { get; private set; }
    public int AttackDamage { get; private set; }
    public int HitDamage { get; private set; }
    public float Speed { get; private set; }
    public float PowerUpDropChance { get; private set; }
    public int AttackSpeed { get; private set; }
    public int Score { get; private set; }

    public EnemyModel(int health, int attackDamage, int hitDamage, float speed, float powerUpDropChance, int attackSpeed, int score)
    {
        Health = health;
        AttackDamage = attackDamage;
        HitDamage = hitDamage;
        Speed = speed;
        PowerUpDropChance = powerUpDropChance;
        AttackSpeed = attackSpeed;
        Score = score;
    }



    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyPowerUpDrop powerUpDrop = GetComponent<EnemyPowerUpDrop>();
        if (powerUpDrop != null)
        {
            powerUpDrop.DropPowerUp();
        }

        // EXP Orbi bırak
        Instantiate(expOrbPrefab, transform.position, Quaternion.identity);

        ScoreManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }

    public void LevelUp(int level)
    {
        Health += level * 2;
        AttackDamage += level + 2;
        HitDamage += level;
        Speed += level * 0.1f;
        PowerUpDropChance += level * 0.01f;

        OnLevelUp?.Invoke(level); // Level up eventini tetikle
    }
}

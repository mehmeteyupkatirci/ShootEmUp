public class EnemyStats : EnemyModel
{
    public EnemyStats(int health, int attackDamage, int hitDamage, float speed, float powerUpDropChance, int attackSpeed, int score)
    {
        Health = health;
        AttackDamage = attackDamage;
        HitDamage = hitDamage;
        Speed = speed;
        PowerUpDropChance = powerUpDropChance;
        AttackSpeed = attackSpeed;
        Score = score;
    }
}

using UnityEngine;

public class PlayerModel
{
    public int Level { get; private set; } = 1;
    public int Exp { get; private set; } = 0;
    public int ExpToNextLevel { get; private set; } = 100;
    public int MaxHealth { get; private set; } = 10;
    public float Speed { get; private set; } = 5f;
    public int Damage { get; private set; } = 1;

    public PlayerModel(int level, int exp, int expToNextLevel, int maxHealth, float speed, int damage)
    {
        Level = level;
        Exp = exp;
        ExpToNextLevel = expToNextLevel;
        MaxHealth = maxHealth;
        Speed = speed;
        Damage = damage;
    }

    public void AddEXP(int amount)
    {
        Exp += amount;
        if (Exp >= ExpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        Exp -= ExpToNextLevel;
        ExpToNextLevel = Mathf.RoundToInt(ExpToNextLevel * 1.5f);

        // Seviye atlama durumunda istatistikleri artır
        IncreaseStats();
    }

    private void IncreaseStats()
    {
        Damage += 1;
        MaxHealth += 1;
        Speed += 0.5f;
    }
}

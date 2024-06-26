using UnityEngine;
using System;

public class PlayerModel
{
     public event Action OnLevelUp; // Level up olduğunda çağrılacak event

    public int MaxHealth { get; set; }
    public int Health {get; set;}
    public float Speed { get; set; }
    public int Damage { get; set; }

   public PlayerModel(int maxHealth, int health, float speed, int damage)
    {
        MaxHealth = maxHealth;
        Health = health;
        Speed = speed;
        Damage = damage;
    }

    public void LevelUp(int level)
    {
        Damage += 1;
        MaxHealth += level;
        Speed += 0.5f;
        Health = MaxHealth;

        OnLevelUp?.Invoke(); // Level up eventini tetikle
    }
}

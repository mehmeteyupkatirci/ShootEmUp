using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { AddProjectile, IncreaseFireRate }
    public PowerUpType powerUpType;
    public float fireRateIncreaseAmount = 0.05f; // Ateş etme hızını azaltma miktarı

    public void ApplyPowerUp(Player player)
    {
        switch (powerUpType)
        {
            case PowerUpType.AddProjectile:
                player.AddProjectile();
                break;
            case PowerUpType.IncreaseFireRate:
                player.IncreaseFireRate(fireRateIncreaseAmount);
                break;
        }
        Destroy(gameObject);
    }
}

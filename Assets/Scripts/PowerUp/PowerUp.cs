using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { AddProjectile, IncreaseFireRate }
    public PowerUpType powerUpType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                ApplyPowerUp(player);
            }
            Destroy(gameObject); // Güçlendirme yok edilir
        }
    }

    public void ApplyPowerUp(Player player)
    {
        switch (powerUpType)
        {
            case PowerUpType.AddProjectile:
                player.AddProjectile();
                break;
            case PowerUpType.IncreaseFireRate:
                player.IncreaseFireRate(0.05f);
                break;
        }
    }

    public void SetPowerUpType(PowerUpType type)
    {
        powerUpType = type;
        // Sprite'ı güncelleme gibi görsel değişiklikler burada yapılabilir
    }
}

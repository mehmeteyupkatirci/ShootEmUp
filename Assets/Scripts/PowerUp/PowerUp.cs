using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        AddProjectile,
        IncreaseFireRate,
        IncreaseHealth // Yeni power-up türü
    }

    public PowerUpType powerUpType;
    public int value = 5; // Power-up değerini tanımlayın (örneğin, can artırma miktarı)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                ApplyPowerUp(player);
                Destroy(gameObject); // Power-up'ı yok et
            }
        }
    }

    private void ApplyPowerUp(Player player)
    {
        switch (powerUpType)
        {
            case PowerUpType.AddProjectile:
                player.AddProjectile();
                break;
            case PowerUpType.IncreaseFireRate:
                player.IncreaseFireRate(0.1f); // Örnek değer
                break;
            case PowerUpType.IncreaseHealth:
                player.IncreaseHealth(value); // Yeni health power-up
                break;
        }
    }

    public void SetPowerUpType(PowerUpType type)
    {
        powerUpType = type;
        // Sprite'ı güncelleme gibi görsel değişiklikler burada yapılabilir
    }
}

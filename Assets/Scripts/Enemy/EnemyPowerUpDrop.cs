using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerUpDrop : MonoBehaviour
{
    public float powerUpDropChance = 0.2f;
    public List<PowerUpData> powerUpList = new List<PowerUpData>();

    public void DropPowerUp()
    {
        if (Random.value < powerUpDropChance)
        {
            GameObject powerUpPrefab = GetRandomPowerUp();
            if (powerUpPrefab != null)
            {
                var powerUpInstance = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
                PowerUp powerUpScript = powerUpInstance.GetComponent<PowerUp>();
                powerUpScript.SetPowerUpType(GetRandomPowerUpType());
            }
        }
    }

    private GameObject GetRandomPowerUp()
    {
        float totalWeight = 0f;
        foreach (var powerUp in powerUpList)
        {
            totalWeight += powerUp.dropChanceWeight;
        }

        float randomPoint = Random.value * totalWeight;

        foreach (var powerUp in powerUpList)
        {
            if (randomPoint < powerUp.dropChanceWeight)
            {
                return powerUp.powerUpPrefab;
            }
            else
            {
                randomPoint -= powerUp.dropChanceWeight;
            }
        }
        return null;
    }

    private PowerUp.PowerUpType GetRandomPowerUpType()
    {
        float randomValue = Random.value;
        if (randomValue < 0.3f)
        {
            return PowerUp.PowerUpType.AddProjectile;
        }
        else
        {
            return PowerUp.PowerUpType.IncreaseFireRate;
        }
    }
}

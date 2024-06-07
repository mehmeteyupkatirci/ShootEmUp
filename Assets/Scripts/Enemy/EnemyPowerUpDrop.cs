using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerUpDrop : MonoBehaviour
{
    public float powerUpDropChance = 0.2f; // Genel drop şansı
    public List<PowerUpData> powerUpList = new List<PowerUpData>();

    public void DropPowerUp()
    {
        if (Random.value < powerUpDropChance)
        {
            PowerUpData selectedPowerUpData = GetRandomPowerUpData();
            if (selectedPowerUpData != null)
            {
                var powerUpInstance = Instantiate(selectedPowerUpData.powerUpPrefab, transform.position, Quaternion.identity);
                PowerUp powerUpScript = powerUpInstance.GetComponent<PowerUp>();
                // Doğru power-up tipini atayın
                powerUpScript.SetPowerUpType(selectedPowerUpData.powerUpType);
            }
        }
    }

    private PowerUpData GetRandomPowerUpData()
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
                return powerUp;
            }
            else
            {
                randomPoint -= powerUp.dropChanceWeight;
            }
        }
        return null;
    }
}

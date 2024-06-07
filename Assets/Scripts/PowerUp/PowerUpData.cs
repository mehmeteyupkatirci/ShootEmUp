using System.Collections;
using UnityEngine;

[System.Serializable]
public class PowerUpData
{
    public GameObject powerUpPrefab;
    public float dropChanceWeight;
    public PowerUp.PowerUpType powerUpType; // Her bir prefab için doğru power-up tipini belirtin
}
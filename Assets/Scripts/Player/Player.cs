using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public event Action<int> OnLevelUp;
    public Slider expSlider;
    public TMP_Text levelText;

    private PlayerModel playerModel;
    private PlayerHealth playerHealth;
    private PlayerShooting playerShooting;

    private void Start()
    {
        playerModel = new PlayerModel(1, 0, 100, 10, 5f, 1);
        playerHealth = GetComponent<PlayerHealth>();
        playerShooting = GetComponent<PlayerShooting>();

        playerHealth.SetMaxHealth(playerModel.MaxHealth);
        playerShooting.StartShooting();
        UpdateHUD();
    }

    public void IncreaseHealth(int amount)
    {
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(amount);
        }
    }

    public void IncreaseFireRate(float amount)
    {
        if (playerShooting != null)
        {
            playerShooting.IncreaseFireRate(amount);
        }
    }

    public void AddProjectile()
    {
        if (playerShooting != null)
        {
            playerShooting.AddProjectile();
        }
    }

    public void AddEXP(int amount)
    {
        playerModel.AddEXP(amount);
        UpdateHUD();
        if (OnLevelUp != null)
        {
            OnLevelUp(playerModel.Level);
        }
    }

    private void UpdateHUD()
    {
        if (expSlider != null)
        {
            expSlider.maxValue = playerModel.ExpToNextLevel;
            expSlider.value = playerModel.Exp;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + playerModel.Level;
        }
    }
}

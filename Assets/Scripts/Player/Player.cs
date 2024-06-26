using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public event Action<int> OnLevelUp;
    public Slider expSlider;
    public TMP_Text levelText;

    private PlayerModel playerModel;
    private LevelModel levelModel;
    private PlayerHealth playerHealth;
    private PlayerShooting playerShooting;

    private void Start()
    {
        // playerModel = new PlayerModel(10 ,10 ,5 ,1);
        levelModel = new LevelModel();
        playerHealth = GetComponent<PlayerHealth>();
        playerShooting = GetComponent<PlayerShooting>();

        // playerHealth.SetMaxHealth(playerModel.MaxHealth);
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
        levelModel.AddEXP(amount);
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (expSlider != null)
        {
            expSlider.maxValue = levelModel.ExpToNextLevel;
            expSlider.value = levelModel.CurrentExp;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + levelModel.Level.ToString();
        }
    }
}

using UnityEngine;

public class LevelModel
{
    public int Level { get; set; }
    public int CurrentExp { get; set; }
    public int ExpToNextLevel { get; set; } = 100;
    private PlayerModel playerModel = new PlayerModel(10,10,5f,1);
    private EnemyModel enemyModel = new EnemyModel();

    public void AddEXP(int amount)
    {
        CurrentExp += amount;
        if (CurrentExp >= ExpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        CurrentExp -= ExpToNextLevel;
        ExpToNextLevel = Mathf.RoundToInt(ExpToNextLevel * 1.5f);

        playerModel.LevelUp(Level);
        enemyModel.LevelUp(Level);
    }
}

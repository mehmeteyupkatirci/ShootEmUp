using System.Collections.Generic;

public static class EnemyDatabase
{
    private static Dictionary<Enemy.EnemyType, EnemyModel> enemyDictionary = new Dictionary<Enemy.EnemyType, EnemyModel>()
    {
        { Enemy.EnemyType.Basic, new EnemyModel(50, 5, 2, 2f, 0.1f, 1, 10) },
        { Enemy.EnemyType.Strong, new EnemyModel(100, 10, 5, 1.5f, 0.2f, 1, 20) },
        { Enemy.EnemyType.Fast, new EnemyModel(30, 3, 1, 3f, 0.05f, 2, 5) },
        { Enemy.EnemyType.Boss, new EnemyModel(500, 20, 10, 1f, 0.5f, 1, 100) }
    };

    public static EnemyModel GetEnemy(Enemy.EnemyType type)
    {
        return enemyDictionary[type];
    }
}

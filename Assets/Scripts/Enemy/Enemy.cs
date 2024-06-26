using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        GetComponent<EnemyMovement>().InitializeMovement();
    }

    public void LevelUpEnemy(int level)
    {
        EnemyShooter shooter = GetComponent<EnemyShooter>();
        if (shooter != null)
        {
            shooter.LevelUp(level);
        }

        EnemyHealth health = GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.LevelUp(level);
        }
    }
}

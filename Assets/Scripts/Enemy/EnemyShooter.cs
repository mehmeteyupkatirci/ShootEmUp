using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireRate;
    private float nextFireTime = 0f;
    private int attackDamage;
    private EnemyModel enemyModel;

    private void Start()
    {
        var enemy = GetComponent<Enemy>();
        enemyModel = enemy.enemyModel;
        attackDamage = enemyModel.AttackDamage;
        fireRate = enemyModel.AttackSpeed;
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<EnemyBullet>().SetDamage(attackDamage);
    }

    public void SetAttackDamage(int newAttackDamage)
    {
        attackDamage = newAttackDamage;
    }

    public void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }
}

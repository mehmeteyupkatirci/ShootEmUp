using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        // Hareketle ilgili işlemler EnemyMovement sınıfında yönetilecektir
        GetComponent<EnemyMovement>().InitializeMovement();
    }
}

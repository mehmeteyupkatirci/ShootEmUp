using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;  // Prefab referansı

    void Start()
    {
        // Player'ı sahneye instantiate et
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
}

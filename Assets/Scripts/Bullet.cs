using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;       // Merminin hareket hızı
    public float lifetime = 2f;     // Merminin ömrü (saniye cinsinden)

    private void Start()
    {
        // Belirli bir süre sonra mermiyi yok et
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Mermiyi ileriye doğru hareket ettir
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}

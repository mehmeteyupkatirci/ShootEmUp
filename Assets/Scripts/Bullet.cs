using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;       // Merminin hareket hızı

    private void Start()
    {

    }

    private void Update()
    {
        // Mermiyi ileriye doğru hareket ettir
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
     void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    public float speed = 10f;

    void Start()
    {
        // Merminin yaşam süresini belirlemek için
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

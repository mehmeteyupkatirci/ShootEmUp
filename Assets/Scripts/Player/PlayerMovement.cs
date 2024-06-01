using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 5f; // Oyuncunun hızı
    private float minX, maxX, minY, maxY;

    void Start()
    {
        // Ekran sınırlarını belirle
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1, 1));
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    void Update()
    {
        // Oyuncu hareketi
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += moveHorizontal * speed * Time.deltaTime;
        position.y += moveVertical * speed * Time.deltaTime;

        // Oyuncunun ekran sınırlarının dışına çıkmasını engelle
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}

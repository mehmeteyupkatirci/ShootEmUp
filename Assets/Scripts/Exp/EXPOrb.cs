using UnityEngine;

public class EXPOrb : MonoBehaviour
{
    public int expAmount = 10; // Bu orb'un sağladığı EXP miktarı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.AddEXP(expAmount);
                Destroy(gameObject); // EXP orb'unu yok et
            }
        }
    }
}

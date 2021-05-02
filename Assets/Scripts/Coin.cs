using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            DataPlayer.Coin += 1;
            Destroy(gameObject);
        }
    }
}

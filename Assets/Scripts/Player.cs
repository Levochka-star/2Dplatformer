using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.gameObject.SetActive(false);
        }

        if (collision.gameObject.TryGetComponent<Island>(out Island island))
        {
            transform.SetParent(island.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Island>(out Island island))
        {
            transform.SetParent(null);
        }
    }
}
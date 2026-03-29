using UnityEngine;

public class Player : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.GetComponent<Island>())
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Island>())
        {
            transform.SetParent(null);
        }
    }
}
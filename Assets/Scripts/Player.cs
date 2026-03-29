using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Коллайдер получен");

        if (collision.gameObject.GetComponent<Coin>())
        {
            collision.gameObject.SetActive(false);
        }
    }
}

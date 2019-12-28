using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Player player;

    public float speed;

    public bool box;
    public bool coin;
    public bool key;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == player.gameObject)
        {
            Debug.Log("Hit player");

            if (box)
            {
                Debug.Log("Box");
                player.canMove = false;
            }

            if (coin)
            {
                Debug.Log("Coin");
                player.coinsCollected += 1;
                Destroy(this.gameObject);
            }

            if (key)
            {
                Debug.Log("Key");
                player.key = true;
            }
        }

        if (collision.gameObject.CompareTag("ObjectDestroyer"))
        {
            Debug.Log("This Object got Destroyed: " + this.name);
            Destroy(this.gameObject);
        }
    }
}

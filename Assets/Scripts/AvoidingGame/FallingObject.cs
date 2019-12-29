using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour
{
    public Player player;
    public ChestController ccSCript;

    public float coins;
    public float speed;

    public bool box;
    public bool coin;
    public bool key;
    public bool endCoin;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        ccSCript = FindObjectOfType<ChestController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == player.gameObject)
        {

            if (box)
            {
                player.canMove = false;
                Destroy(this.gameObject);
            }

            if (coin)
            {
                player.coinsCollected += 1;
                Destroy(this.gameObject);
            }

            if (key)
            {
                player.key = true;
                Destroy(this.gameObject);
            }
            if (endCoin)
            {
                ccSCript.coinsEnd += 1;
                player.coinsCollected += 1;
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("ObjectDestroyer"))
        {
            Debug.Log("This Object got Destroyed: " + this.name);
            Destroy(this.gameObject);
        }
    }
}

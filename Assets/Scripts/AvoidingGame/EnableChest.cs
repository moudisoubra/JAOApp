using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChest : MonoBehaviour
{
    public bool giveCoins;
    public Player player;
    public ChestController ccScript;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        ccScript = FindObjectOfType<ChestController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (giveCoins)
        {
            if (ccScript.transform.position == ccScript.chestPlaceholder.transform.position)
            {
                ccScript.open = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            ccScript.comeDown = true;
            if (player.key)
            {
                giveCoins = true;
            }
            else
            {
                Debug.Log("Player Doesnt Have Key!");
            }
            player.start = false;
        }
    }
}

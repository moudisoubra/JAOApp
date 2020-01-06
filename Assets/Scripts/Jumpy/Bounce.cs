using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public JumpyPlayer player;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = FindObjectOfType<JumpyPlayer>().GetComponent<Rigidbody2D>();
        player = FindObjectOfType<JumpyPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == playerRB.gameObject && playerRB.velocity.y <= 0)
        {
            player.ChangeColors();
            playerRB.AddForce(Vector3.up * force);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == playerRB.gameObject && playerRB.velocity.y <= 0)
        {
            player.ChangeColors();
            playerRB.AddForce(Vector3.up * force);
        }
    }
}

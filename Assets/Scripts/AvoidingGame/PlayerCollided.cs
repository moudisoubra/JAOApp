using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollided : MonoBehaviour
{
    public Player player;
    public FollowBezierCurve fbcScript;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fbcScript.playerFollow)
        {
            player.transform.position = fbcScript.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            fbcScript.coroutineAllowed = true;
        }
    }
}

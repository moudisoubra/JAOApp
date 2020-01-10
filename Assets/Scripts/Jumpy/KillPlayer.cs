using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool endGame;
    public GameObject[] players;

    public GameObject firstText;
    public GameObject endText;
    public GameObject rightButton;
    public GameObject leftButton;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            firstText.transform.position = Vector3.Lerp(firstText.transform.position, endText.transform.position, speed);
            firstText.transform.localScale = Vector3.Lerp(firstText.transform.localScale, endText.transform.localScale, speed);
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<JumpyPlayer>())
        {
            endGame = true;
            for (int i = 0; i < players.Length; i++)
            {
                Destroy(players[i].gameObject);
            }
        }
    }
}

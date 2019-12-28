using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDuration : MonoBehaviour
{
    public float gameDuration;
    public float gameTimer;
    public Text gameTimerText;
    public bool start;
    public GameObject wall;
    public Player playerScript;
    public Spawning spawnScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        spawnScript = FindObjectOfType<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            gameTimer += Time.deltaTime;
            gameTimerText.text = gameTimer.ToString("0");
            if (gameTimer > gameDuration)
            {
                wall.SetActive(false);
                playerScript.start = false;
                spawnScript.spawn = false;
                start = false;
            }
        }
    }
}

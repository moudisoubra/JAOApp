using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDuration : MonoBehaviour
{
    public float gameTimer;
    public Text gameTimerText;
    public bool start;
    public GameObject goText;
    public GameObject wall;
    public Player playerScript;
    public Spawning spawnScript;
    public MoveCamera mcScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        spawnScript = FindObjectOfType<Spawning>();
        mcScript = FindObjectOfType<MoveCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            gameTimer -= Time.deltaTime;
            gameTimerText.text = gameTimer.ToString("0");
            if (gameTimer <= 1)
            {
                gameTimerText.text = "";
                goText.SetActive(true);
                wall.SetActive(false);
                //playerScript.start = false;
                spawnScript.spawn = false;
                mcScript.Go = true;
                start = false;
            }
        }
    }
}

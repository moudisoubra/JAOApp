using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Player playerScript;
    public Spawning spawnScript;
    public GameDuration gdScript;
    public GameObject[] assets;
    public GameObject startText;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        spawnScript = FindObjectOfType<Spawning>();
        gdScript = FindObjectOfType<GameDuration>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnScript.spawn = start;
        playerScript.start = start;
        gdScript.start = start;

        if (start)
        {
            for (int i = 0; i < assets.Length; i++)
            {
                assets[i].SetActive(true);
            }

            startText.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }

    public void ToggleStart()
    {
        start = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public bool spawn;
    public Player player;
    public GameObject[] spawners;
    public GameObject[] spawnees;
    public float timer;
    public float timerDuration;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
                    timer += Time.deltaTime;

        if (timer > timerDuration)
        {
            GameObject spawner = spawners[Random.Range(0, spawners.Length)];
            GameObject spawnedObject;

            if (player.key)
            {
                Debug.Log("CANNOT SPAWN KEy");
                spawnedObject = spawnees[Random.Range(1, spawnees.Length)];
            }
            else
            {
                 spawnedObject = spawnees[Random.Range(0, spawnees.Length)];
            }

            Instantiate(spawnedObject, spawner.transform.position, Quaternion.identity);
            timer = 0;
        }
        }
    }
}

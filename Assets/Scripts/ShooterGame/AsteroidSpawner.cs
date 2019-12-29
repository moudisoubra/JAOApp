using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public bool spawn;
    public GameObject[] spawners;
    public GameObject[] spawnees;
    public float timer;
    public float timerDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        spawn = true;
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

                spawnedObject = spawnees[Random.Range(0, spawnees.Length)];


                GameObject temp =Instantiate(spawnedObject, spawner.transform.position, Quaternion.identity);
                temp.GetComponent<Asteroid>().speed = Random.Range(2, 10);
                timer = 0;
            }
        }
    }
}

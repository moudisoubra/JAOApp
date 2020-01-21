using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiPrefab;
    public GameObject startRange;
    public GameObject endRange;
    public float timer;
    public float timerDuration;
    public bool startGame;

    void Start()
    {
        
    }


    void Update()
    {
        if (startGame)
        {
            timer += Time.deltaTime;
            if (timer > timerDuration)
            {
                Instantiate(zombiPrefab, new Vector3(Random.Range(startRange.transform.position.x, endRange.transform.position.x), -0.631f, 0), Quaternion.identity);
                timer = 0;
            }
        }
    }
}

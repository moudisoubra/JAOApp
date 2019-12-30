using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public GameObject[] prefabs;
    public float timer;
    public float timerDuration;
    public float randomTimeDuration;
    public int randomNumber;
    
    void Start()
    {
        randomTimeDuration = Random.Range(4, timerDuration);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > randomTimeDuration)
        {
            randomTimeDuration = Random.Range(0, timerDuration);
            randomNumber = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomNumber], transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}

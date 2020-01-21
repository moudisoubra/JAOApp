using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappyObstacleSpawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public float height;
    public GameObject obstaclePrefab;
    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newObstacle, 25);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime && canSpawn)
        {
            GameObject newObstacle = Instantiate(obstaclePrefab);
            newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newObstacle, 25);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public int life;
    public int OGlife;
    public Vector2 direction;
    public GameObject[] possibleLocations;
    public GameObject[] babyAsteroids;
    public MoveScoreText mstScript;
    public AsteroidSpawner asScript;
    // Start is called before the first frame update
    void Start()
    {
        OGlife = life;
        mstScript = FindObjectOfType<MoveScoreText>();
        asScript = FindObjectOfType<AsteroidSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed;

        if (life <= 0)
        {
                SpawnBabyAsteroids();
        }
    }

    public void SpawnBabyAsteroids()
    {
        GameObject oneLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];
        GameObject twoLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];
        GameObject threeLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];

        while (twoLocation == oneLocation)
        {
            twoLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];
        }

        while (threeLocation == oneLocation)
        {
            threeLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];
        }

        while (twoLocation == threeLocation)
        {
            twoLocation = possibleLocations[Random.Range(0, possibleLocations.Length)];
        }

        GameObject one = Instantiate(babyAsteroids[Random.Range(0, babyAsteroids.Length)], oneLocation.transform.position, Quaternion.identity);
        GameObject two = Instantiate(babyAsteroids[Random.Range(0, babyAsteroids.Length)], twoLocation.transform.position, Quaternion.identity);
        GameObject three = Instantiate(babyAsteroids[Random.Range(0, babyAsteroids.Length)], threeLocation.transform.position, Quaternion.identity);

        one.GetComponent<BabyAsteroid>().parent = this.gameObject;
        two.GetComponent<BabyAsteroid>().parent = this.gameObject;
        three.GetComponent<BabyAsteroid>().parent = this.gameObject;
        mstScript.scoreNum += OGlife;
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ObjectDestroyer"))
        {
            Destroy(this.gameObject);
        }

        if (other.GetComponent<PlayerShip>())
        {
            Destroy(other.gameObject);
            asScript.spawn = false;
            mstScript.end = true;
        }
    }
}

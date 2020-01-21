using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flap : MonoBehaviour
{
    public Swipe swipe;
    public Rigidbody2D rb;
    public float velocity = 1;
    public float speed;
    public int points;
    public bool startTapping;
    public Text scoreText;
    public GameObject endButton;
    public TappyObstacleSpawner script;
    public GameObject firstText;
    public GameObject endText;
    public GameObject stopTap;
    void Start()
    {
        startTapping = true;
        rb = GetComponent<Rigidbody2D>();
        swipe = FindObjectOfType<Swipe>();
        script = FindObjectOfType<TappyObstacleSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!startTapping)
        {
            endButton.SetActive(true);
        }
        // if (swipe.Tap && startTapping)
        // {
        //     rb.velocity = Vector2.up * velocity;
        // }
        scoreText.text = points.ToString("0");

        if (!script.canSpawn)
        {
            firstText.transform.position = Vector3.Lerp(firstText.transform.position, endText.transform.position, speed);
            firstText.transform.localScale = Vector3.Lerp(firstText.transform.localScale, endText.transform.localScale, speed);
            stopTap.SetActive(false);
        }
    }

    public void Flappity()
    {
        rb.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            points += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            script.canSpawn = false;
            startTapping = false;
        }
    }
}

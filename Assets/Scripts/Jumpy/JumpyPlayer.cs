using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpyPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text topScoreText;
    public GameObject killer;
    public SpriteRenderer[] sprites;
    public Color[] colors;
    public float moveInput;
    public float speed = 10f;
    public float topScore = 0.0f;
    public float x;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void StartGame()
    {
        rb.simulated = true;
    }

    private void Update()
    {
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
            killer.transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        }

        topScoreText.text = Mathf.Round(topScore).ToString("0");
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    public void MoveRight()
    {
        while (x < 1)
        {
            Debug.Log("Moving Right");
            x += 0.1f;
        }
    }
    public void MoveLeft()
    {
        while (x > -1)
        {
            Debug.Log("Moving Left");
            x -= 0.1f;
        }
    }
    public void StopMoving()
    {
        x = 0;
    }

    public void ChangeColors()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            Color randomColor = colors[Random.Range(0, colors.Length)];
            sprites[i].color = randomColor;
        }
    }
}

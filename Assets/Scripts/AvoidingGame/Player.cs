using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float coinsCollected;
    public float speed;
    public float stunTimer;
    public float stunTimerDuration;

    public bool start;
    public bool key;
    public bool canMove;

    public bool moveRight;
    public bool moveLeft;

    public Animator playerAnimator;
    public SpriteRenderer sr;
    public Text coinAmount;

    public GameObject keyObject;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        keyObject.SetActive(false);
    }


    void Update()
    {
        coinAmount.text = coinsCollected.ToString();
        keyObject.SetActive(key);

        if (start)
        {
            
        if (!canMove)
        {
            stunTimer += Time.deltaTime;
            playerAnimator.SetBool("Fall", true);
            if (stunTimer > stunTimerDuration)
            {
                stunTimer = 0;
                playerAnimator.SetBool("Fall", false);
                canMove = true;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            playerAnimator.SetBool("Run", Input.GetKey(KeyCode.D));
            MovePlayer(1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
            playerAnimator.SetBool("Run", Input.GetKey(KeyCode.A));
            MovePlayer(-1);
        }

        if (moveRight && canMove)
        {
            sr.flipX = false;
            MovePlayer(1);
        }

        if (moveLeft && canMove)
        {
            sr.flipX = true;
            MovePlayer(-1);
        }
        }
    }

    public void MoveLeft()
    {
        moveLeft = true;
        playerAnimator.SetBool("Run", true);
    }

    public void StopMovingLeft()
    {
        moveLeft = false;
        playerAnimator.SetBool("Run", false);
    }

    public void MoveRight()
    {
        moveRight = true;
        playerAnimator.SetBool("Run", true);
    }

    public void StopMovingRight()
    {
        moveRight = false;
        playerAnimator.SetBool("Run", false);
    }
    public void MovePlayer(int modifier)
    {
        transform.position += new Vector3(speed * modifier, 0,0);
    }
}

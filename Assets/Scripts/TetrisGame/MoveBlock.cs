using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float previousTime;
    public float fallTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallTime = fallTime / 10;
        }
        else
        {
            fallTime = 0.8f;
        }

        if (Time.time - previousTime > fallTime)
        {
            FallingTetris();
        }

    }
    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }

    public void FallingTetris()
    {
        transform.position += new Vector3(0, -1, 0);
        previousTime = Time.time;
    }
}

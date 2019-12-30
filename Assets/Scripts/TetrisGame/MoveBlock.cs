using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    public float previousTime;
    public float fallTime = 0.8f;
    public static int height = 32;
    public static int width = 13;
    public static Transform[,] grid = new Transform[width, height];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            RotateTetris();
        }
        if (Input.GetKey(KeyCode.S))
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
        CheckForLines();
    }
    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(1, 0, 0);
        }
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }

    public void RotateTetris()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }

    public void FallingTetris()
    {
        transform.position += new Vector3(0, -1, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(0, -1, 0);
            AddToGrid();
            CheckForLines();
            this.enabled = false;
            FindObjectOfType<TetrisSpawner>().SpawnBlock();
        }
        previousTime = Time.time;
    }

    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j,i] == null)
            {
                return false;
            }
        }

        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int X = Mathf.RoundToInt(child.transform.position.x);
            int Y = Mathf.RoundToInt(child.transform.position.y);

            grid[X, Y] = child;
        }
    }
    bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int X = Mathf.RoundToInt(child.transform.position.x);
            int Y = Mathf.RoundToInt(child.transform.position.y);

            if (X < 0 || X >= width || Y < 0 || Y >= height)
            {
                return false;
            }
            if (grid[X,Y] != null)
            {
                return false;
            }
        }
        return true;
    }
}

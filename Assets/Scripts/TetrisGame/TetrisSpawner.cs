using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisSpawner : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject[] blockFrames;
    public GameObject currentBlock;
    public GameObject nextBlock;
    public GameObject gameOver;
    public GameObject endButton;
    public Text scoreText;
    public float scoreNum;
    public Text timeText;
    public float timeNum;
    public int nextBlockNum;
    public bool spawn;
    public bool firstSpawn;
    void Start()
    {
        spawn = true;


    }


    void Update()
    {
        if (firstSpawn)
        {
            nextBlockNum = Random.Range(0, blocks.Length);
            nextBlock = blocks[nextBlockNum];
            SpawnBlock();
            firstSpawn = false;
        }
        scoreText.text = scoreNum.ToString("0");
        timeText.text = timeNum.ToString("00");

        if (timeNum <= 0)
        {
            spawn = false;
        }
        else if (spawn)
        {
            timeNum -= Time.deltaTime;
        }

        for (int i = 0; i < blockFrames.Length; i++)
        {
            if (nextBlock.name == blockFrames[i].name)
            {
                blockFrames[i].SetActive(true);
            }
            else
            {
                blockFrames[i].SetActive(false);
            }
        }

        if (!spawn)
        {
            timeNum = 0;
            gameOver.SetActive(true);
            endButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        firstSpawn = true;
    }
    public void MoveRight()
    {
        currentBlock.GetComponent<MoveBlock>().MoveRight();
    }
    public void MoveLeft()
    {
        currentBlock.GetComponent<MoveBlock>().MoveLeft();
    }
    public void MoveDown()
    {
        currentBlock.GetComponent<MoveBlock>().fallTime = currentBlock.GetComponent<MoveBlock>().fallTime / 10;
    }

    public void SpawnBlock()
    {
        Instantiate(nextBlock, transform.position, Quaternion.identity);
        nextBlockNum = Random.Range(0, blocks.Length);
        nextBlock = blocks[nextBlockNum];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScoreText : MonoBehaviour
{
    public Text score;
    public Text time;
    public float scoreNum;
    public float speed;
    public float gameTime;
    public bool start;
    public bool end;
    public Transform placeHolder;
    public Animation animation;
    public AsteroidSpawner asScript;
    public GameObject buttonEnd;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        animation = GetComponent<Animation>();
        asScript = FindObjectOfType<AsteroidSpawner>();
    }

    public void StartGame()
    {
        start = true;
    }
    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreNum.ToString("0") + " !!";
        if (start && !end)
        {
            scoreNum += Time.deltaTime;
            gameTime -= Time.deltaTime;
            time.text = gameTime.ToString("0");
        }
        if (end)
        {
            time.text = " ";
            this.transform.position = Vector3.Lerp(transform.position, placeHolder.position, speed);

            if (this.transform.position == placeHolder.position)
            {
                animation.Play();
            }
            buttonEnd.SetActive(true);
        }

        if (gameTime <= 0)
        {
            end = true;
            asScript.spawn = false;
        }
    }
}

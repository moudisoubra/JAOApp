using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public GameObject chestPlaceholder;
    public GameObject openChest;
    public GameObject coin;
    public GameObject endButton;
    public float speed;
    public float waitTime;
    public float coinsEnd;
    public int randomNum;
    public bool open;
    public bool comeDown;
    public bool showCoins;
    public GameObject coins;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(3, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if (comeDown)
        {
            transform.position = Vector3.Lerp(this.transform.position, chestPlaceholder.transform.position, speed);
        }
        if (open)
        {
            openChest.SetActive(true);

            //for (int i = 0; i < randomNum; i++)
            //{
            //    GameObject temp =
            //    Instantiate(coin, chestPlaceholder.transform.position, Quaternion.identity);
            //    temp.GetComponent<FollowBezierCurve>().routes[0] = chestPlaceholder.transform;
            //}
            coins.SetActive(true);
            showCoins = true;
            StartCoroutine(Spawn());
            open = false;
        }
        if (showCoins)
        {
            coins.GetComponent<Text>().text = ("+ ") + coinsEnd.ToString();
        }
    
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < randomNum; i++)
        {
            GameObject temp =
            Instantiate(coin, chestPlaceholder.transform.position, Quaternion.identity);
            temp.GetComponent<FollowBezierCurve>().routes[0] = chestPlaceholder.transform;
            yield return new WaitForSeconds(waitTime);

        }
        endButton.SetActive(true);
    }
}

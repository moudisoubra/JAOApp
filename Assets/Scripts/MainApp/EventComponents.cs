using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;
public class EventComponents : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public string votedFor;
    public string votedAgainst;
    public string totalVoted;
    public string ID;
    public bool showButtons;
    public GameObject buttons;
    public string userID;
    public LoginSystem lsScript;
    public float timer;
    public float timerDuration;

    // Start is called before the first frame update
    void Start()
    {
        lsScript = FindObjectOfType<LoginSystem>();
        userID = lsScript.user.user_ID;
        StartCoroutine(GetBool("https://testserversoubra.herokuapp.com/CheckArray/" + ID + "/" + userID));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        buttons.SetActive(showButtons);

        if (timer > timerDuration)
        {
            StartCoroutine(GetBool("https://testserversoubra.herokuapp.com/CheckArray/" + ID + "/" + userID));
            timer = 0;
        }
    }
    IEnumerator GetRequest(string uri)
    {
        //Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log("Here");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string data = webRequest.downloadHandler.text;
            Debug.Log(data);
        }
    }

    IEnumerator GetBool(string uri)
    {
        //Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log("Here");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string data = webRequest.downloadHandler.text;
            Debug.Log("BOOL: " + data);

            if (data.Contains("True"))
            {
                showButtons = false;
            }
            else if(data.Contains("False"))
            {
                showButtons = true;
            }
        }
    }

    public void AddToArray()
    {
        //"/updateEventArray/:eventID/:memberID"
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/updateEventArray/" + ID + "/" + userID));
    }
    public void VoteFor()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/AddToPositive/" + ID + "/1"));
        AddToArray();
        Debug.Log("https://testserversoubra.herokuapp.com/AddToPositive/" + ID + "/1");
    }

    public void VoteAgainst()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/AddToNegative/" + ID + "/1"));
        AddToArray();
        Debug.Log("https://testserversoubra.herokuapp.com/AddToNegative/" + ID + "/1");
    }
}

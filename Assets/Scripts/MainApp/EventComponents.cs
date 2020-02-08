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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void VoteFor()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/AddToPositive/" + ID + "/1"));
        Debug.Log("https://testserversoubra.herokuapp.com/AddToPositive/" + ID + "/1");
    }

    public void VoteAgainst()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/AddToNegative/" + ID + "/1"));
        Debug.Log("https://testserversoubra.herokuapp.com/AddToNegative/" + ID + "/1");
    }
}

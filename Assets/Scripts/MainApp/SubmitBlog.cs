using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SubmitBlog : MonoBehaviour
{
    public TMP_InputField inputField;
    public string blogContent;
    public string userName;
    public string userID;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Submit()
    {
        blogContent = inputField.text.ToString();
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/CreateBlogPost/"+ userID +"/"+ userName +"/"+ blogContent));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Blog Submit Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}

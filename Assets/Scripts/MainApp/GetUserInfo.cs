using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetUserInfo : MonoBehaviour
{
    public User1 user;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/FindUser/Soubra"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            User1 data = JsonUtility.FromJson<User1>(webRequest.downloadHandler.text);

                print("User ID: " + data.user_ID +
                " User Name: " + data.user_Name +
                " User Password: " + data.user_Password +
                " User Gender: " + data.user_Gender +
                " User Seniority: " + data.user_Seniority
                + "User House: "+ data.user_House + 
                "User Login: " + data.user_Login);

            user = data;


        }
    }

    [System.Serializable]
    public class User1
    {
        public string user_ID;
        public string user_Password;
        public string user_Name;
        public string user_Gender;
        public string user_Seniority;
        public int user_House;
        public string user_Login;
    }
}

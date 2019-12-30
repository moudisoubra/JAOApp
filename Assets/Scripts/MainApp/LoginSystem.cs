using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class LoginSystem : MonoBehaviour
{
    public User user;

    public InputField userName;
    public InputField password;
    public TextMeshProUGUI connection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        string login = "https://testserversoubra.herokuapp.com/Login/" + userName.text.ToString() + "/" + password.text.ToString();
        //Debug.Log(login);
        StartCoroutine(GetRequest(login));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");
        connection.SetText("Logging in...");
        connection.color = Color.green;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            var data = webRequest.downloadHandler.text;

            if (data.Contains("Wrong Password"))
            {
                print(data);
                connection.SetText("Wrong Password...");
                connection.color = Color.red;
            }
            else if (data.Contains("Didn't find a user with that Login"))
            {
                connection.SetText("Username not found...");
                connection.color = Color.red;
                print(data);
            }
            else
            {
                connection.SetText("");
                User userData = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);

                print("user id: " + userData.user_ID +
                " user name: " + userData.user_Name +
                " user password: " + userData.user_Password +
                " user gender: " + userData.user_Gender +
                " user seniority: " + userData.user_Seniority +
                "user house: " + userData.user_House +
                "user login: " + userData.user_Login);

                user = userData;
            }


        }
    }

    [System.Serializable]
    public class User
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

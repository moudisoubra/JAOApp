using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class LoginSystem : MonoBehaviour
{
    public User user;
    public pics pic;
    public RawImage RI;
    public Texture2D tex;
    public Texture2D webTex;
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField newPassword;
    public TextMeshProUGUI connection;
    public AppColorPicker acpScript;
    public ChangePanel cpScript;
    public string panelName;

    public string storedUserName;
    public string storedPassword;
    public GameObject login;
    public GameObject noLogin;

    public bool erasePlayerPrefs;

    // Start is called before the first frame update
    void Start()
    {
        acpScript = GetComponent<AppColorPicker>();
        //StartCoroutine(GetRequestPic("https://testserversoubra.herokuapp.com/showPicture/123"));
        //StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/Login/Soubra/123"));
        
        Debug.Log(PlayerPrefs.GetString("Password") + " AND " + string.IsNullOrEmpty(storedPassword) );
        storedPassword = PlayerPrefs.GetString("Password");
        storedUserName = PlayerPrefs.GetString("UserName");

        if (!string.IsNullOrEmpty(storedPassword) || !string.IsNullOrEmpty(storedUserName))
        {
            login.SetActive(true);
            noLogin.SetActive(false);
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/Login/" + storedUserName + "/" + storedPassword));
        }
        else
        {
            login.SetActive(false);
            noLogin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(erasePlayerPrefs)
        {
            PlayerPrefs.SetString("UserName", null);
            PlayerPrefs.SetString("Password", null);
            erasePlayerPrefs = false;
        }
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

                PlayerPrefs.SetString("UserName", user.user_Name);
                PlayerPrefs.SetString("Password", user.user_Password);


                acpScript.SetColorNumber(user.user_House);

                if(user.resetPassword == "0")
                {
                    panelName = "ResetPassword";
                    //cpScript.ChangeToPanel("ResetPassword");
                }
                else
                {
                    panelName = "Home";
                    //cpScript.ChangeToPanel("Home");
                }

            }


        }

    }

    IEnumerator Change(string uri)
    {
        //Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log("Here");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string data = webRequest.downloadHandler.text;
        }
    }

    public void ChangePassword()
    {
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/ChangePassword/" + user.user_ID + "/" + newPassword.text.ToString()));
        PlayerPrefs.SetString("Password", newPassword.text.ToString());
    }
    
    IEnumerator GetRequestPic(string uri)
    {
        Debug.Log("Pic Coroutine Started");
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

        using (WWW www = new WWW(uri))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
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
        public string resetPassword;
    }

    [System.Serializable]
    public class pics
    {
        public string imgName;
        public RawImage img;
    }
}

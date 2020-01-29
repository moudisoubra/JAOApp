using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class AwardComponents : MonoBehaviour
{
    public User user;
    public Texture2D tex;
    public SpriteRenderer sprite;
    public RawImage ri;
    public TextMeshProUGUI name;
    public TextMeshProUGUI awardContent;
    public string ID;
    public bool applyImage;

    public void Start()
    {
        StartCoroutine(GetRequestPic("https://testserversoubra.herokuapp.com/showPicture/" + ID));
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/FindUser/" + ID));
        applyImage = true;
    }

    public void Update()
    {
        if (applyImage && tex != null)
        {
            ri.texture = tex;
            applyImage = false;
        }
        name.text = user.user_Name;
    }
    IEnumerator GetRequestPic(string uri)
    {
        Debug.Log("Pic Coroutine Started: " + uri);
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

        using (WWW www = new WWW(uri))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
        }

    }
    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            var data = webRequest.downloadHandler.text;

                User userData = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);

            user = userData;


            


        }

    }
    [System.Serializable]
    public class User
    {
        public string user_ID;
        public string user_Name;
    }
}

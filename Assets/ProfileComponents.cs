using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileComponents : MonoBehaviour
{
    public string userID;
    public TextMeshProUGUI name;
    public TextMeshProUGUI nationality;
    public TextMeshProUGUI property;
    public TextMeshProUGUI department;
    public TextMeshProUGUI position;
    public Texture2D tex;
    public RawImage rawImage;
    public bool getPic = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(userID != "" && !getPic)
        {
            StartCoroutine(GetRequestPic("https://testserversoubra.herokuapp.com/showPicture/" + userID));
        }
    }

    IEnumerator GetRequestPic(string uri)
    {
        Debug.Log("Pic Coroutine Started: " + uri);
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

        using (WWW www = new WWW(uri))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            rawImage.texture = tex;
            getPic = true;
        }

    }
}

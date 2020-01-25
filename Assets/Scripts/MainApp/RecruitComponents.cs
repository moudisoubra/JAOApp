using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RecruitComponents : MonoBehaviour
{

    public Texture2D tex;
    public SpriteRenderer sprite;
    public RawImage ri;
    public TextMeshProUGUI name;
    public TextMeshProUGUI nationality;
    public TextMeshProUGUI property;
    public TextMeshProUGUI department;
    public TextMeshProUGUI position;
    public TextMeshProUGUI doj;
    public string ID;
    public bool applyImage;

    public void Start()
    {
        StartCoroutine(GetRequestPic("https://testserversoubra.herokuapp.com/showPicture/" + ID));
        applyImage = true;
    }

    public void Update()
    {
        if (applyImage && tex != null)
        {
            ri.texture = tex;
            applyImage = false;
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
        }

    }
}

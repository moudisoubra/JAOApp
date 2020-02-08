using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DyanmicHeight : MonoBehaviour
{
    public GameObject textBox;
    public GameObject image;
    public float textBoxSize;
    public float imageSize;
    public float offset;

    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        imageSize = image.GetComponent<RectTransform>().sizeDelta.y;
        textBoxSize = textBox.GetComponent<RectTransform>().sizeDelta.y;

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, (imageSize + offset) + textBoxSize);

        
    }
}

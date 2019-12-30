using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundsMainMenu : MonoBehaviour
{
    public RawImage background;
    public Texture[] backgroundImages;
    public float timer;
    public float timerReset;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        timer = 0;//
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timerReset)
        {
            if(index >= backgroundImages.Length - 1)
            {
                index = -1;
            }
            index++;
            timer = 0;
        }

        background.texture = backgroundImages[index];
    }


}

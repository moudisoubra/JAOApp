using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSwitcher : MonoBehaviour
{
    public RawImage target;
    public Texture[] rawImages;
    public int index;
    public float timer;
    public float timeInterval;

    void Start()
    {
        index = 0;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeInterval)
        {
            index++;
            timer = 0;
        }
        if (index > rawImages.Length - 1)
        {
            index = 0;
            target.texture = rawImages[index];
        }
        else if (index <= rawImages.Length)
        {
            target.texture = rawImages[index];
        }
    }
}

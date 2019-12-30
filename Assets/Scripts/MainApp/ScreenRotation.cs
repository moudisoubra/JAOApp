using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotation : MonoBehaviour
{
    public bool portrait;
    public bool landscape;
    // Start is called before the first frame update
    void Start()
    {
        if (portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        if (landscape)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

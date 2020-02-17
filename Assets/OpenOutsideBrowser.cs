using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOutsideBrowser : MonoBehaviour
{
    public string websiteName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenExternal()
    {
        Application.OpenURL(websiteName);
    }
}

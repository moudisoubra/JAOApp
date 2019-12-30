using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{

    public GameObject[] allPanels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToPanel(string panelName)
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            if (allPanels[i].name == panelName)
            {
                allPanels[i].SetActive(true);
            }
            else
            {
                allPanels[i].SetActive(false);
            }
        }
    }
}

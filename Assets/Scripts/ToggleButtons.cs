using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    public Sprite appButton;
    public Sprite XButton;

    public GameObject AppButton;
    public GameObject ReadingRoomButton;
    public GameObject StatisticsButton;
    public GameObject IdeaGeneratorButton;
    public GameObject CommunicationButton;
    public GameObject ToolsButton;
    public GameObject HomeButton;
    public GameObject ProfileButton;

    public GameObject ReadingRoomButtonPlaceHolder;
    public GameObject StatisticsButtonPlaceHolder;
    public GameObject IdeaGeneratorButtonPlaceHolder;
    public GameObject CommunicationButtonPlaceHolder;
    public GameObject ToolsButtonPlaceHolder;
    public GameObject HomeButtonPlaceHolder;
    public GameObject ProfileButtonPlaceHolder;

    public GameObject shade;
    public GameObject[] allPanels;

    public float lerpSpeed;
    public bool spread;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spread)
        {
            SpreadButtons();
            shade.SetActive(true);
            AppButton.GetComponent<Image>().sprite = XButton;
            EnlargeButtons();
        }
        else if (!spread)
        {
            ReturnButtons();
            shade.SetActive(false);
            AppButton.GetComponent<Image>().sprite = appButton;
            SmallButtons();
        }
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

    public void EnableSpread()
    {
        spread = !spread;
    }
    public void SpreadButtons()
    {
        ReadingRoomButton.transform.position = Vector3.Lerp(ReadingRoomButton.transform.position, ReadingRoomButtonPlaceHolder.transform.position, lerpSpeed);
        StatisticsButton.transform.position = Vector3.Lerp(StatisticsButton.transform.position, StatisticsButtonPlaceHolder.transform.position, lerpSpeed);
        IdeaGeneratorButton.transform.position = Vector3.Lerp(IdeaGeneratorButton.transform.position, IdeaGeneratorButtonPlaceHolder.transform.position, lerpSpeed);
        CommunicationButton.transform.position = Vector3.Lerp(CommunicationButton.transform.position, CommunicationButtonPlaceHolder.transform.position, lerpSpeed);
        ToolsButton.transform.position = Vector3.Lerp(ToolsButton.transform.position, ToolsButtonPlaceHolder.transform.position, lerpSpeed);
        HomeButton.transform.position = Vector3.Lerp(HomeButton.transform.position, HomeButtonPlaceHolder.transform.position, lerpSpeed);
        ProfileButton.transform.position = Vector3.Lerp(ProfileButton.transform.position, ProfileButtonPlaceHolder.transform.position, lerpSpeed);
    }

    public void ReturnButtons()
    {
        ReadingRoomButton.transform.position = Vector3.Lerp(ReadingRoomButton.transform.position, AppButton.transform.position, lerpSpeed);
        StatisticsButton.transform.position = Vector3.Lerp(StatisticsButton.transform.position, AppButton.transform.position, lerpSpeed);
        IdeaGeneratorButton.transform.position = Vector3.Lerp(IdeaGeneratorButton.transform.position, AppButton.transform.position, lerpSpeed);
        CommunicationButton.transform.position = Vector3.Lerp(CommunicationButton.transform.position, AppButton.transform.position, lerpSpeed);
        ToolsButton.transform.position = Vector3.Lerp(ToolsButton.transform.position, AppButton.transform.position, lerpSpeed);
        HomeButton.transform.position = Vector3.Lerp(HomeButton.transform.position, AppButton.transform.position, lerpSpeed);
        ProfileButton.transform.position = Vector3.Lerp(ProfileButton.transform.position, AppButton.transform.position, lerpSpeed);
    }

    public void EnlargeButtons()
    {

            HomeButton.transform.localScale = Vector3.Lerp(HomeButton.transform.localScale, HomeButtonPlaceHolder.transform.localScale, lerpSpeed);
            ProfileButton.transform.localScale = Vector3.Lerp(ProfileButton.transform.localScale, ProfileButtonPlaceHolder.transform.localScale, lerpSpeed);
        
    }

    public void SmallButtons()
    {

            HomeButton.transform.localScale = Vector3.Lerp(HomeButton.transform.localScale, AppButton.transform.localScale, lerpSpeed);
            ProfileButton.transform.localScale = Vector3.Lerp(ProfileButton.transform.localScale, AppButton.transform.localScale, lerpSpeed);
        
    }
}

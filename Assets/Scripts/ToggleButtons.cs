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

    public GameObject ReadingRoomButtonPlaceHolder;
    public GameObject StatisticsButtonPlaceHolder;
    public GameObject IdeaGeneratorButtonPlaceHolder;
    public GameObject CommunicationButtonPlaceHolder;
    public GameObject ToolsButtonPlaceHolder;

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
            AppButton.GetComponent<Image>().sprite = XButton;
        }
        else if (!spread)
        {
            ReturnButtons();
            AppButton.GetComponent<Image>().sprite = appButton;
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
    }

    public void ReturnButtons()
    {
        ReadingRoomButton.transform.position = Vector3.Lerp(ReadingRoomButton.transform.position, AppButton.transform.position, lerpSpeed);
        StatisticsButton.transform.position = Vector3.Lerp(StatisticsButton.transform.position, AppButton.transform.position, lerpSpeed);
        IdeaGeneratorButton.transform.position = Vector3.Lerp(IdeaGeneratorButton.transform.position, AppButton.transform.position, lerpSpeed);
        CommunicationButton.transform.position = Vector3.Lerp(CommunicationButton.transform.position, AppButton.transform.position, lerpSpeed);
        ToolsButton.transform.position = Vector3.Lerp(ToolsButton.transform.position, AppButton.transform.position, lerpSpeed);
    }
}

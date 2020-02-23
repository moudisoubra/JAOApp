using UnityEngine;
using UnityEngine.UI;

public class AppColorPicker : MonoBehaviour
{
    public Texture mainColor;
    public Texture[] colors = new Texture[4];
    public Texture[] hubBackgrounds = new Texture[4];

    public RawImage[] backgrounds;
    public RawImage mainHubBack;

    public Sprite[] JobsButtons;
    public Image JobsButton;

    public Sprite[] NewsButtons;
    public Image NewsButton;

    public Sprite[] ArrivalsButtons;
    public Image ArrivalsButton;

    public Sprite[] EventsButtons;
    public Image EventsButton;

    public Sprite[] AwardsButtons;
    public Image AwardsButton;

    public Sprite[] ToolsButtons;
    public Image[] ActualToolsButtons;

    public Sprite[] characters;
    public Image mainCharacter;

    public bool changeColor;

    public int color;

    public ChangePanel cpScript;
    public LoginSystem lsScript;

    //0:Red
    //1:Blue
    //2:Green
    //3:Purple
    
    void Start()
    {
        
    }

    void Update()
    {
        ChangeBackgroundColor();
    }

    public void SetColorNumber(int c)
    {
        color = c;
        changeColor = true;
    }

    public void changeAll(int c)
    {
        mainColor = colors[c];
        mainHubBack.texture = hubBackgrounds[c];
        mainCharacter.sprite = characters[c];

        if (changeColor)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].texture = mainColor;
            }
            JobsButton.sprite = JobsButtons[c];
            NewsButton.sprite = NewsButtons[c];
            ArrivalsButton.sprite = ArrivalsButtons[c];
            EventsButton.sprite = EventsButtons[c];
            AwardsButton.sprite = AwardsButtons[c];
            changeColor = false;

            cpScript.ChangeToPanel(lsScript.panelName);
        }
    }

    public void ChangeBackgroundColor()
    {
        switch (color)
        {
            case 0:
                changeAll(color);
                break;

            case 1:
                changeAll(color);
                break;

            case 2:
                changeAll(color);
                break;

            case 3:
                changeAll(color);
                break;
        }
    }
}

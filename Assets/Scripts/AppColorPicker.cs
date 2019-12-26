using UnityEngine;
using UnityEngine.UI;

public class AppColorPicker : MonoBehaviour
{
    public Texture mainColor;
    public Texture[] colors = new Texture[4];
    public Texture[] hubBackgrounds = new Texture[4];

    public RawImage[] backgrounds;
    public RawImage mainHubBack;

    public Sprite[] characters;
    public Image mainCharacter;

    public bool changeColor;

    public int color;

    public ChangePanel cpScript;



    
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
            changeColor = false;
            cpScript.ChangeToPanel("Home");
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

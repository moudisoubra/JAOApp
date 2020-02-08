using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddIngredient : MonoBehaviour
{
    public StringVariable ingredient;
    public CheckPizza cpScript;
    public TextMeshProUGUI text;
    public TextMeshProUGUI centralText;
    // Start is called before the first frame update
    void Start()
    {
        cpScript = FindObjectOfType<CheckPizza>();
        centralText = GameObject.FindGameObjectWithTag("Central").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredient != null)
        {
            text.text = ingredient.value;
        }
        else
        {
            text.text = "NULL";
        }

    }

    public void AddToPlayerPizza()
    {
        cpScript.playerPizza.Add(ingredient);
        cpScript.ingredientsleftNumber -= 1;
        centralText.text = text.text;
    }
}

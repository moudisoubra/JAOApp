using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPizza : MonoBehaviour
{
    public StringArray allIngredients;
    public StringArray testPizza;
    public StringArray chosenPizza;
    public List<StringVariable> playerPizza;
    public List<StringVariable> ingredientsAdded;
    public List<StringVariable> ingredientsAddedToButtons;
    public List<StringVariable> buttonIngredients;
    public List<AddIngredient> buttons;
    public List<StringArray> allPizzas;

    public int points;
    public int ingredientsRight;
    public int ingredientsOrderRight;
    public int ingredientsleftNumber;
    public int ingredientsAddedToButtonsNumber;
    public int contains;

    public bool allCorrectIngredients;
    public bool allCorrectIngredientsOrder;
    public bool startGame;
    public bool endGame;
    public bool endGameStop;

    public TextMeshProUGUI pizzaName;
    public TextMeshProUGUI ingredientsLeftText;
    public TextMeshProUGUI correctIng;
    public TextMeshProUGUI totalPoints;

    public GameObject panel;
    public GameObject yes;
    public GameObject no;
    void Start()
    {
        //CheckIngredients(testPizza, testPizza2);
        points = 0;
        ingredientsRight = 0;
        ingredientsOrderRight = 0;
        chosenPizza = allPizzas[Random.Range(0, allPizzas.Count)];
        startGame = true;
    }

    public void StartGame()
    {
        startGame = true;
        endGame = false;
        endGameStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        yes.SetActive(allCorrectIngredientsOrder);
        no.SetActive(!allCorrectIngredientsOrder);
        if (startGame)
        {
            playerPizza.Clear();
            ingredientsAdded.Clear();
            ingredientsAddedToButtons.Clear();
            buttonIngredients.Clear();

            chosenPizza = allPizzas[Random.Range(0, allPizzas.Count)];

            pizzaName.text = chosenPizza.name;
            ingredientsleftNumber = chosenPizza.values.Count;
            ingredientsLeftText.text = "Ingredients Left: " + ingredientsleftNumber.ToString("0");

            for (int i = 0; i < chosenPizza.values.Count; i++)
            {
                ingredientsAdded.Add(chosenPizza.values[i]);

            }

            while (ingredientsAdded.Count < 10)
            {
                int otherTempValue = Random.Range(0, allIngredients.values.Count);
                if (!ingredientsAdded.Contains(allIngredients.values[otherTempValue]))
                {
                    ingredientsAdded.Add(allIngredients.values[otherTempValue]);
                }
            }


            while (ingredientsAddedToButtons.Count < 10)
            {

                int tempNumber = Random.Range(0, ingredientsAdded.Count);
                if (!ingredientsAddedToButtons.Contains(ingredientsAdded[tempNumber]))
                {
                    ingredientsAddedToButtons.Add(ingredientsAdded[tempNumber]);
                    ingredientsAddedToButtonsNumber += 1;
                }

            }

            for (int i = 0; i < ingredientsAddedToButtons.Count; i++)
            {
                buttons[i].ingredient = ingredientsAddedToButtons[i];
            }

            for (int i = 0; i < chosenPizza.values.Count; i++)
            {
                if (ingredientsAdded.Contains(chosenPizza.values[i]))
                {
                    contains += 1;
                }
            }

            if (contains == chosenPizza.values.Count)
            {
                Debug.Log("ALL INGREDIENTS IN");
            }

            startGame = false;
        }
        if (ingredientsleftNumber <= 0 && chosenPizza != null)
        {
            endGame = true;
        }
        else
        {
            endGame = false;
        }
        if (endGame && !endGameStop)
        {
            CheckIngredients(chosenPizza, playerPizza);
            if (allCorrectIngredients)
            {
                //points += 10;
            }
            if (allCorrectIngredientsOrder)
            {
                points += 100;
            }

            correctIng.text = "+" + ingredientsRight.ToString("0");
            totalPoints.text = points.ToString("0");

            panel.SetActive(true);
            endGame = false;
            endGameStop = true;
        }
        ingredientsLeftText.text = "Ingredients Left: " + ingredientsleftNumber.ToString("0");
    }

    public void CheckIngredients(StringArray chosenPizza, List<StringVariable> playerPizza)
    {
        for (int i = 0; i < chosenPizza.values.Count; i++)
        {
            if (chosenPizza.values[i].value == playerPizza[i].value)
            {
                points += 1;
            }

            if (playerPizza.Contains(chosenPizza.values[i]))
            {
                ingredientsRight += 1;
            }

            if (playerPizza[i].value == chosenPizza.values[i].value)
            {
                ingredientsOrderRight += 1;
            }
        }

        if (ingredientsOrderRight == chosenPizza.values.Count)
        {
            allCorrectIngredientsOrder = true;
            
        }
        if (ingredientsRight == chosenPizza.values.Count)
        {
            allCorrectIngredients = true;
        }
        else
        {
            allCorrectIngredients = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadIngredient : MonoBehaviour
{
    public StringReference ingredient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ingredient.variable.value);
    }
}

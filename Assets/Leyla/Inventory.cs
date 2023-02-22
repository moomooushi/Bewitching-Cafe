using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] ingredients;
    public GameObject selectedIngredient;
    public GameObject ingredientSpawnPoint;
    
    [Header("Temp ingredient storages")]
    public GameObject blueberry;
    public GameObject frog;
    public GameObject toad;


    //This function is checking if there's enough of the ingredient. If there is, remove from amount - (which is child of label - (which is child of ingredient))
    public void PickIngredient(string ingredientName)//ensure the button has the name of the ingredient its attached to.
    {
        foreach (GameObject ingredient in ingredients)//grabbing the gameobject based off its name so I dont have to attach a script to each ingredient
        {
            if (ingredientName == ingredient.name)
            {
                selectedIngredient = ingredient;
            }
        }
        
        GameObject label = selectedIngredient.transform.GetChild(1).gameObject;
        GameObject amount = label.transform.GetChild(0).gameObject;
        int.TryParse(amount.GetComponent<TextMeshProUGUI>().text, out int number);
        
        if (number > 0)//if the ingredient is available
        {
            print("taking 1 " + ingredientName);
            number -= 1;
            amount.GetComponent<TextMeshProUGUI>().text = number.ToString();

        }
        else if (number == 0)
        {
            print("youre out of " + ingredientName);
        }
    }
}

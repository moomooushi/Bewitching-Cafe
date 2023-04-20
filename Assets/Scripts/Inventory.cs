using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ingredients;
using ScriptableObjects.Ingredients;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public GameObject[] ingredients;
    public Sprite[] presentIngredients;
    public Sprite[] missingIngredients;
    public GameObject selectedIngredient;
    public GameObject ingredientSpawnPoint;
    public GameObject poof;
    
    [Header("Ingredient Storage")]
    public GameObject[] ingredientPrefabs;

    string ingredientName;
    public GameObject envelopeButton;
    private int cost;
    public GameObject moneyCounter;

    public float cooldownTime = 1f;
    private bool ingredientPressed = false;

    //This function is checking if there's enough of the ingredient. If there is, remove from amount - (which is child of label - (which is child of ingredient))
    public void PickIngredient(string ingredientName)//ensure the button has the name of the ingredient its attached to.
    {
        if (!ingredientPressed)
        {
            foreach (GameObject ingredient in ingredients)//grabbing the gameobject based off its name so I dont have to attach a script to each ingredient
            {
                //print(ingredientName + ingredient.name);
                if (ingredientName == ingredient.name)
                {
                    selectedIngredient = ingredient;
                }
            }
        
            GameObject label = selectedIngredient.transform.GetChild(0).gameObject;
            GameObject amount = label.transform.GetChild(0).gameObject;
            int.TryParse(amount.GetComponent<TextMeshProUGUI>().text, out int number);
        
            if (number > 0)//if the ingredient is available
            {
                print("taking 1 " + ingredientName);
                number -= 1;
                amount.GetComponent<TextMeshProUGUI>().text = number.ToString();

                foreach (GameObject prefab in ingredientPrefabs)
                {
                    if (selectedIngredient.name == prefab.name)
                    {
                        Instantiate(prefab, ingredientSpawnPoint.transform.position, transform.rotation);
                        ingredientPressed = true;
                    }
                }

            }
            if (number == 0)
            {
                foreach (Sprite missingIgredient in missingIngredients)
                {
                    if (missingIgredient.name.Contains(selectedIngredient.name))
                    {
                        selectedIngredient.GetComponent<Image>().sprite = missingIgredient;
                    }
                }
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(poof, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                print("youre out of " + ingredientName);
            }

            StartCoroutine(MakeIngredientClickable());
        }
    }
    private void Update()
    {
        foreach (GameObject ingredient in ingredients)
        {
            GameObject label = ingredient.transform.GetChild(0).gameObject;
            GameObject amount = label.transform.GetChild(0).gameObject;
            int.TryParse(amount.GetComponent<TextMeshProUGUI>().text, out int number);
            if (number > 0)
            {
                foreach (Sprite presentIgredient in presentIngredients)
                {
                    if (presentIgredient.name.Contains(ingredient.name))
                    {
                        ingredient.GetComponent<Image>().sprite = presentIgredient;
                    }
                }
            }
        }
    }

    public void IncreaseIngredient(string name)
    {
        foreach (GameObject ingredient in ingredients)
        {
            if (name.Contains(ingredient.name))
            {
                GameObject label = ingredient.transform.GetChild(0).gameObject;
                GameObject amount = label.transform.GetChild(0).gameObject;
                int.TryParse(amount.GetComponent<TextMeshProUGUI>().text, out int number);
                number += 1;
                amount.GetComponent<TextMeshProUGUI>().text = number.ToString();
                foreach (Sprite presentIgredient in presentIngredients)
                {
                    if (presentIgredient.name.Contains(ingredient.name))
                    {
                        ingredient.GetComponent<Image>().sprite = presentIgredient;
                    }
                }
            }
        }
    }

    public void Buy(string ingredientName)//ensure the button has the name of the ingredient its attached to.
    {
        foreach (GameObject ingredient in ingredients)//grabbing the gameobject based off its name so I dont have to attach a script to each ingredient
        {
            //print(ingredientName + ingredient.name);
            if (ingredientName == ingredient.name)
            {
                selectedIngredient = ingredient;
            }
            if (selectedIngredient.name == "Blueberry" || selectedIngredient.name == "Rose Quartz" || selectedIngredient.name == "Toad")//temp solution to calculate cost because im too tired to do this more efficiently
            {
                cost = 100;
            }
            else if (selectedIngredient.name == "Beetle" || selectedIngredient.name == "Mushy" || selectedIngredient.name == "Mandrake")
            {
                cost = 80;
            }
            else if (selectedIngredient.name == "Skull" || selectedIngredient.name == "Toxic Butterfly" || selectedIngredient.name == "Carnelian")
            {
                cost = 50;
            }
        }

        GameObject label = selectedIngredient.transform.GetChild(0).gameObject;
        GameObject amount = label.transform.GetChild(0).gameObject;
        int.TryParse(amount.GetComponent<TextMeshProUGUI>().text, out int number);
        print(envelopeButton.GetComponent<LetterOrders>().money + " > " + cost);

        if (envelopeButton.GetComponent<LetterOrders>().money >= cost)//if the ingredient is available
        {
            print("buying 1 " + ingredientName);
            number += 1;
            envelopeButton.GetComponent<LetterOrders>().money -= cost;
            amount.GetComponent<TextMeshProUGUI>().text = number.ToString();
            moneyCounter.GetComponent<TextMeshProUGUI>().text = "$" + envelopeButton.GetComponent<LetterOrders>().money;
        }
    }

    IEnumerator MakeIngredientClickable()
    {
        yield return new WaitForSeconds(.75f);
        ingredientPressed = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetterOrders : MonoBehaviour
{
    public string[] potionTypes;
    public string[] potionCustomers;
    public GameObject letterText;

    public string potion;
    public int amount;
    public int amountCount;

    public string potionCustomer;

    public int maxPotions;
    public int maxCustomers;
    
    void Start()
    {
        foreach(string potion in potionTypes)
        {
            maxPotions ++;
        }
        foreach(string customer in potionCustomers)
        {
            maxCustomers ++; // get max for randomly choosing the customer later. This makes it easer to add on more customers in the inspector as we dont need to change the maximum manually
        }
        amountCount = 0;
        NewOrder();
    }

    public void ConfirmOrder()
    {// if order is correct, new order, if not...? Check if potions are present in storage
        amountCount = 0;
        GameObject[] madePotions = GameObject.FindGameObjectsWithTag("Potion"); //make sure the potions have the tag on them
        foreach (GameObject madePotion in madePotions)//checking if one of  the potions in the scene are what the customer asked for
        {
            if (madePotion.name == potion + "(Clone)")
            {
                amountCount += 1;
            }
            if (amount != amountCount)
            {
                print(madePotion.name + " is not " + potion);
                letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n<u><b><color=#EA2E00>" + amount + " " + potion + "</color></b></u>\n\nThank you,\n" + potionCustomer;
            }
        }
        if (amountCount >= amount)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);//until we have a way to scavenge resources or move on to cafe scene cuz we'll run out of ingredients
        }
    }

    void NewOrder()
    {// Hello Witch Cat I need: (choose random potionTypes) Thanks, (potionCustomers)
        amount = Random.Range(1, 3);
        potion = potionTypes[Random.Range(0,maxPotions)];
        potionCustomer = potionCustomers[Random.Range(0,maxCustomers)];
        letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n<u>" + amount + " "+ potion + "</u>\n\nThank you,\n" + potionCustomer;
    }

    private void Update()
    {
        GameObject[] madePotions = GameObject.FindGameObjectsWithTag("Potion"); //make sure the potions have the tag on them
        foreach (GameObject madePotion in madePotions)//checking if one of  the potions in the scene are what the customer asked for
        {
            if (madePotion.name == potion + "(Clone)" && amount == amountCount)
            {
                letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n<u><color=#71C36B>" + amount + " " + potion + "</color></u>\n\nThank you,\n" + potionCustomer;
            }
        }
    }
}

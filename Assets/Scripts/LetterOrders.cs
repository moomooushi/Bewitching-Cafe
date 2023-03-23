using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
//using Random = System.Random;

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

    public int money;
    public int ordersComplete;

    public GameObject moneyCounter;
    public GameObject orderCounter;

    public GameObject correctOrder;
    public GameObject wrongOrder;
    public GameObject[] potionLabel;
    int i;
    
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
        foreach (GameObject madePotion in madePotions)//checking if one of the potions in the scene are what the customer asked for
        {
            if (madePotion.name == potion + "(Clone)")
            {
                amountCount += 1;
            }
        }
        if (amountCount >= amount)
        {
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);//until we have a way to scavenge resources or move on to cafe scene cuz we'll run out of ingredients
            correctOrder.SetActive(true);
            money += 125;
            ordersComplete += 1;
            moneyCounter.GetComponent<TextMeshProUGUI>().text = "$" + money;
            orderCounter.GetComponent<TextMeshProUGUI>().text = ordersComplete + " Orders Completed";
            foreach (GameObject madePotion in madePotions)//checking if one of the potions in the scene are what the customer asked for
            {
                if (madePotion.name == potion + "(Clone)")
                {
                        Destroy(madePotion);
                        foreach (GameObject potion in potionLabel)
                        {
                            print(madePotion.name + " " + potion.name);
                            if (madePotion.name.Contains(potion.name))
                            {
                                GameObject label = potion.transform.GetChild(0).gameObject;
                                int.TryParse(label.GetComponent<TextMeshProUGUI>().text, out int number);
                                number = 0;
                                label.GetComponent<TextMeshProUGUI>().text = number.ToString();
                            }
                        }
                }
            }
        }
        else if (amount != amountCount)
        {
            letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n<u><b><color=#EA2E00>" + amount + " " + potion + "</color></b></u>\n\nThank you,\n" + potionCustomer;
            wrongOrder.SetActive(true);
            money -= 50;
            moneyCounter.GetComponent<TextMeshProUGUI>().text = "$" + money;
        }
    }

    public void NewOrder()
    {// Hello Witch Cat I need: (choose random potionTypes) Thanks, (potionCustomers)
        amount = UnityEngine.Random.Range(1, 3);
        potion = potionTypes[UnityEngine.Random.Range(0,maxPotions)];
        potionCustomer = potionCustomers[UnityEngine.Random.Range(0,maxCustomers)];
        letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n<u>" + amount + " "+ potion + "</u>\n\nThank you,\n" + potionCustomer;
    }
}

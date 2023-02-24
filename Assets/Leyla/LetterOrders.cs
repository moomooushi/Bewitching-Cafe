using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterOrders : MonoBehaviour
{
    public string[] potionTypes;
    public string[] potionCustomers;
    public GameObject letterText;

    public string potion;
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
            maxCustomers ++;
        }
    }

    public void ConfirmOrder()
    {// if order is correct, new order, if not...? Check if potions are present in storage
        NewOrder();
    }

    void NewOrder()
    {// Hello Witch Cat I need: (choose random potionTypes) Thanks, (potionCustomers)
        potion = potionTypes[Random.Range(0,maxPotions)];
        potionCustomer = potionCustomers[Random.Range(0,maxCustomers)];
        letterText.GetComponent<TextMeshProUGUI>().text = "Hello Witch Cat,\n\nI Need:\n* " + potion + "\n\nThank you,\n" + potionCustomer;
    }
}

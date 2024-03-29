using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject narrator;
    [SerializeField] GameObject focusWindow;
    [SerializeField] GameObject okay;
    [SerializeField] GameObject orderCompleteButton;
    public int stage;
    public int shopStage;
    [SerializeField] bool healingMade;

    private void Update()
    {
        if (stage == 0)//introduction
        {
            orderCompleteButton.SetActive(false);
            focusWindow.SetActive(true);
            focusWindow.transform.localPosition = new Vector2(-97, -110);
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Hello! I'm Kat, a witch, and I've employed you to help me. I need your opposable thumbs to help me with my orders";//orders position Vector2(341.299988,179.899994)
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
            okay.SetActive(true);
        }
        if (stage == 1)//introduce orders
        {
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the letter to look at the order";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 18;
            focusWindow.transform.localPosition = new Vector2(340, 180);//orders position Vector2(341.299988,179.899994)
            focusWindow.transform.localScale = new Vector2(1, 1);
        }
        else if (stage == 2)//introduce potion making
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);
            focusWindow.SetActive(false);
            narrator.transform.localPosition = new Vector2(260, -40);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "It looks like they want<color=\"red\"> 1 healing potion</color>, click on the<color=#00ffffff><b> X </b></color>to close";
        }
        else if (stage == 3)
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the books to look at recipes";
            focusWindow.SetActive(true);
            narrator.transform.localPosition = new Vector2(-114, 46);
        }
        else if (stage == 4)
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "The recipes are in riddles for security, but I'll help you this time. We'll need a <color=\"red\">blueberry and rose quartz</color>, click on the<color=#00ffffff><b> X </b></color>to close";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
            narrator.transform.localPosition = new Vector2(260, -40);
            focusWindow.SetActive(false);
        }
        else if (stage == 5)
        {
            focusWindow.SetActive(true);
            focusWindow.transform.localScale = new Vector2(1.4f, 2.6f);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "These are the ingredients, you'll find more types later, greyed out ones are out of stock";
            okay.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 16;
            narrator.transform.localPosition = new Vector2(-114, 7.5f);
            focusWindow.transform.localPosition = new Vector2(-280, 0);
        }
        else if (stage == 6)//click blueberry
        {
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "I need you to click a blueberry for me";
            focusWindow.transform.localScale = new Vector2(0.5f, 0.5f);
            focusWindow.transform.localPosition = new Vector2(-307, 120);
        }
        else if (stage == 7)//click rose quartz
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Lastly I need you to get me a rose quartz";
            focusWindow.transform.localPosition = new Vector2(-305, -22);
        }

        GameObject[] madePotions = GameObject.FindGameObjectsWithTag("Potion");
        foreach (GameObject madePotion in madePotions)//checking if one of the potions in the scene are what the customer asked for
        {
            if (madePotion.name.Contains("Healing"))
            {
                healingMade = true;
            }
        }
        if (stage == 8 && healingMade == true)
        {
            focusWindow.transform.localScale = new Vector2(1, 1);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "You've made a healing potion! Time to go complete the order";
            focusWindow.transform.localPosition = new Vector2(341.299988f, 179.899994f);
        }
        else if (stage == 9)
        {
            narrator.transform.localPosition = new Vector2(260, -40);
            focusWindow.SetActive(false);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click <color=\"green\">Complete!</color> to recieve payment";
            orderCompleteButton.SetActive(true);
        }
        else if (stage == 10)//accept new order
        {
            orderCompleteButton.SetActive(false);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Let's see what the new order is, click the <color=#00ffffff>New Order";
        }
        else if (stage == 11)//exit
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "We have a new order, but we're out of ingredients, click on the<color=#00ffffff><b> X </b></color>to close";
        }
        else if (stage == 12)
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "I'll show you how to get more ingredients, click on the door";
            narrator.transform.localPosition = new Vector2(-114, 46);
            focusWindow.transform.localPosition = new Vector2(229, -105);
            focusWindow.transform.localScale = new Vector2(1.7f, 1.7f);
            orderCompleteButton.SetActive(true);
            focusWindow.SetActive(true);
        }
        else if (stage == 13)
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "There are 3 different places, my farm, mine and backyard. Each have 3 different types of ingredients";
            okay.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
        }
        else if (stage == 14)//mining
        {
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "For now let's go to the mine. Click it";
            narrator.transform.localScale = new Vector2(1, 1);
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 17;
        }
        else if (stage == 15)//mining info
        {
            narrator.transform.localPosition = new Vector2(-280, -125);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "In the mines all you have to do is click rocks to mine them and uncover ingredients and click them. When you're done click <color=#00ffffff><b>back";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
            focusWindow.SetActive(false);
            okay.SetActive(true);
        }
        else if (stage == 17)//outside menu
        {
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click on the door again";
            narrator.transform.localPosition = new Vector2(-114, 46);
            focusWindow.transform.localPosition = new Vector2(229, -105);
            focusWindow.SetActive(true);
        }
        else if (stage == 18)//catching
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Now let's go to the backyard. Click Catch";
            narrator.transform.localPosition = new Vector2(-114, 46);
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 18;
            focusWindow.SetActive(true);
        }
        else if (stage == 19)//catching info
        {
            narrator.transform.localPosition = new Vector2(-280, -125);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "In the backyard you need click on the critters to catch them. When you're done click <color=#00ffffff><b>back";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
            focusWindow.SetActive(false);
            okay.SetActive(true);
        }
        else if(stage == 21)
        {
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click on the door again";
            narrator.transform.localPosition = new Vector2(-114, 46);
            focusWindow.transform.localPosition = new Vector2(229, -105);
            focusWindow.SetActive(true);
        }
        else if (stage == 22)//Farming
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Now let's go to the farm. Click Farm";
            narrator.transform.localPosition = new Vector2(-114, 46);
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 18;
            focusWindow.SetActive(true);
        }
        else if (stage == 23)//Farming info
        {
            narrator.transform.localPosition = new Vector2(170, 40);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "In the Farm you need to plant seeds or spores to grow them and harvest. Click the Buy button of the ingredient you want to grow";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
            focusWindow.SetActive(false);
        }
        else if (stage == 24)//Farming info
        {
            narrator.transform.localPosition = new Vector2(-280, 0);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Now Click on one of the dirt mounds on the ground to plant. This costs money";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
        }
        else if (stage == 26)//Farming info
        {
            narrator.transform.localPosition = new Vector2(-280, 0);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "The ingredient will start growing, click it once it's fully grown to harvest it";
            focusWindow.SetActive(false);
            okay.SetActive(true);
        }
        else if (stage == 27)//Farming info
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "If you want to change what you're planting click Cancel then Buy of whatever you want to plant. When you're done click <color=#00ffffff><b>back";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
            narrator.SetActive(true);
            okay.SetActive(true);
        }
        if (shopStage == 1)//shop
        {
            narrator.transform.localPosition = new Vector2(-114, 7.5f);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "This is a sigil that when clicked, opens the <b><u>shop</u></b>. Under it is our <b><u>money";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 17;
            narrator.SetActive(true);
            focusWindow.SetActive(true);
            focusWindow.transform.localPosition = new Vector2(64, 105);
            focusWindow.transform.localScale = new Vector2(1, 1);
        }
        else if (shopStage == 2)
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Here you buy or sell ingredients. You will only really need to come here if you're out of money and need to buy seeds";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 14;
            narrator.transform.localPosition = new Vector2(90, -30f);
            okay.SetActive(true);
            focusWindow.SetActive(false);
        }
        else if (shopStage == 3)
        {
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "That's everything. Time to get to work!";
            narrator.GetComponentInChildren<TextMeshProUGUI>().fontSize = 20;
            narrator.transform.localPosition = new Vector2(90, -30f);
            okay.SetActive(true);
            focusWindow.SetActive(false);
        }
        else if (stage == 100)//skip tutorial
        {
            focusWindow.SetActive(false);
            narrator.SetActive(false);
            orderCompleteButton.SetActive(true);
            shopStage = 100;
        }

    }

    public void NextStage()
    {
        //if the selected button is the right name and stage number,
        stage++;
    }
    public void NextShopStage()
    {
        //if the selected button is the right name and stage number,
        shopStage++;
    }

    public void SkipTutorial()
    {
        stage = 100;
        orderCompleteButton.SetActive(true);
    }
}

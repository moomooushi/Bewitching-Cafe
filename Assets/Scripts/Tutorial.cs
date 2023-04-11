using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject narrator;
    [SerializeField] GameObject focusWindow;

    [SerializeField] GameObject orders;
    [SerializeField] GameObject recipebook;
    [SerializeField] GameObject shop;
    public int stage;
    [SerializeField] bool healingMade;

    private void Update()
    {
        if (stage == 1)//introduce orders
        {
            recipebook.GetComponent<UnityEngine.UI.Button>().interactable = false;
            shop.GetComponent<UnityEngine.UI.Button>().interactable = false;
            focusWindow.SetActive(true);
            narrator.SetActive(true);//Vector3(-260,-40,0)
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the letter to accept an order";//orders position Vector2(341.299988,179.899994)
        }
        else if (stage == 2)//introduce potion making
        {
            orders.GetComponent<UnityEngine.UI.Button>().interactable = false;
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            focusWindow.SetActive(false);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "It looks like they want<color=\"red\"> 1 healing potion</color>, click on the<color=#00ffffff><b> X </b></color>to close";
        }
        else if (stage == 3)
        {
            recipebook.GetComponent<UnityEngine.UI.Button>().interactable = true;
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the books to look at recipes";
            focusWindow.SetActive(true);
        }
        else if (stage == 4)
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "The recipes are in riddles but I'll help you this time. We'll need a <color=\"red\">blueberry and rose quartz</color>, click on the<color=#00ffffff><b> X </b></color>to close";
            focusWindow.SetActive(false);
            recipebook.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else if (stage == 5)
        {
            focusWindow.SetActive(true);
            focusWindow.transform.localScale = new Vector2(1.4f, 2.6f);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "These are the ingredients, let's click the <color=\"red\"> blueberry and rose quartz";
            narrator.transform.localPosition = new Vector2(272.5f, -35.4000015f);
            focusWindow.transform.localPosition = new Vector2(-280, 0);
        }
        GameObject[] madePotions = GameObject.FindGameObjectsWithTag("Potion");
        foreach (GameObject madePotion in madePotions)//checking if one of the potions in the scene are what the customer asked for
        {
            if (madePotion.name.Contains("Healing"))
            {
                healingMade = true;
            }
        }
        if (stage == 5 && healingMade == true)
        {
            focusWindow.transform.localScale = new Vector2(1, 1);
            orders.GetComponent<UnityEngine.UI.Button>().interactable = true;
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "You've made a healing potion! Time to go complete the order";
            focusWindow.transform.localPosition = new Vector2(341.299988f, 179.899994f);
        }
        else if(stage == 6)
        {
            focusWindow.SetActive(false);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click 'Complete!' to recieve payment";
        }
        else if (stage == 50)
        {
            focusWindow.SetActive(false);
            narrator.SetActive(false);
            orders.GetComponent<UnityEngine.UI.Button>().interactable = true;
            recipebook.GetComponent<UnityEngine.UI.Button>().interactable = true;
            shop.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }

    }
    public void NextStage()
    {
        stage++;
    }
    public void SkipTutorial()
    {
        stage = 50;
    }
}

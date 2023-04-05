using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject narrator;
    [SerializeField] GameObject focusWindow;
    [SerializeField] GameObject clickSpot;
    public int stage;

    private void Update()
    {
        if (stage == 0)//introduce orders
        {
            focusWindow.SetActive(true);
            clickSpot.SetActive(true);
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the letter to accept an order";//orders position Vector2(341.299988,179.899994)
            //if clickspot clicked stage++;
        }
        else if (stage == 1)//introduce potion making
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            clickSpot.transform.localPosition = new Vector2();
            focusWindow.SetActive(false);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "It looks like they want 1 healing potion, click on the X to close";
        }
        else if (stage == 2)
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            clickSpot.transform.localPosition = new Vector2();
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the books to look at recipes";
            focusWindow.SetActive(true);
        }
        else if (stage == 3)
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            clickSpot.transform.localPosition = new Vector2();
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "This is the potion we'll be making, we'll need a <color=\"red\"> blue berry and Carnelian";
            focusWindow.SetActive(false);
        }
        else if (stage == 4)
        {

        }

    }

}

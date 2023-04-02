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
        if (stage == 1)//introduce orders
        {
            focusWindow.SetActive(true);
            clickSpot.SetActive(true);
            narrator.SetActive(true);
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the letter to accept an order";
            //if clickspot clicked stage++;
        }
        else if (stage == 2)//introduce potion making
        {
            focusWindow.transform.localPosition = new Vector2(250, 10);//recipebook location
            clickSpot.transform.localPosition = new Vector2();
            narrator.GetComponentInChildren<TextMeshProUGUI>().text = "Click the books to look at recipes";
        }
        else if (stage == 3)
        {
            //orders position Vector2(341.299988,179.899994)
        }
        else if (stage == 4)
        {

        }
        else if (stage == 5)
        {

        }

    }

}

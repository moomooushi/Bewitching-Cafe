using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    LetterOrders letterOrders;
    public TextMeshProUGUI moneyTxt;

    public GameObject inventoryManager;
    public GameObject envelopeButton;
    public int fmMoney;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        fmMoney = envelopeButton.GetComponent<LetterOrders>().money;
        moneyTxt.GetComponent<TextMeshProUGUI>().text = "$" + envelopeButton.GetComponent<LetterOrders>().money;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            selectPlant.btnImage.color = buyColor;
            selectPlant.btnText.text = "Buy";
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            if(selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnText.text = "Buy";
            }
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnText.text = "Cancel";
            isPlanting = true;
        }
    }

    public void Transaction(int value)
    {
        fmMoney -= value;
    }
}

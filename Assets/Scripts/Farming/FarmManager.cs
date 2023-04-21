using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class FarmManager : MonoBehaviour
{
    public PlantItem plantItem;
    public PlantObject plantObject;
    public bool isPlanting = false;
    LetterOrders letterOrders;
    public TextMeshProUGUI moneyTxt;

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
        print(newPlant);
        plantItem = newPlant;
        print("SelectPlant"+ newPlant);
        print(plantItem);
        if(plantItem == newPlant)
        {
            plantItem.btnImage.color = buyColor;
            plantItem.btnText.text = "Buy";
            isPlanting = true;
            plantItem = newPlant;
            plantItem.btnImage.color = cancelColor;
            plantItem.btnText.text = "Cancel";
            //isPlanting = false;
        }
        else
        {
            print("elseplant");
            if(plantItem != null)
            {
                print("plant null");
                plantItem.btnImage.color = buyColor;
                plantItem.btnText.text = "Buy";
            }
            isPlanting = false;
        }
    }

    public void Transaction(int value)
    {
        fmMoney -= value;
    }
}

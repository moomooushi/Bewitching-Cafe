using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;


    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
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

}

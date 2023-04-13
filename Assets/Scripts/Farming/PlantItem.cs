using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public TextMeshProUGUI seedsLeftTxt;

    public Image btnImage;
    public TextMeshProUGUI btnText;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought" + plant.plantName);
        fm.SelectPlant(this);
    }

}

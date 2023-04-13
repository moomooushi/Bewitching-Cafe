using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    SpriteRenderer plot;

    PlantObject selectedPlant;

    FarmManager fm;

    [SerializeField] GameObject inventoryManager;
    public int mandrakeSeedsLeft;
    public int mushySeedsLeft;
    public int blueberrySeedsLeft;
    [SerializeField] TextMeshProUGUI mandrakeSeedsLeftTxt;
    [SerializeField] TextMeshProUGUI mushySeedsLeftTxt;
    [SerializeField] TextMeshProUGUI blueberrySeedsLeftTxt;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if(timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }

        mandrakeSeedsLeftTxt.SetText("$" + mandrakeSeedsLeft);
        mushySeedsLeftTxt.SetText("$" + mushySeedsLeft);
        blueberrySeedsLeftTxt.SetText("$" + blueberrySeedsLeft);
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            //We want to harvest if crop is planted
            if(plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
        }
        else if(fm.isPlanting && selectedPlant.plantName == "Mandrake" && mandrakeSeedsLeft > 0)
        {
            Plant(fm.selectPlant.plant);
            mandrakeSeedsLeft--;
        }
        else if (fm.isPlanting && selectedPlant.plantName == "Blueberry" && blueberrySeedsLeft > 0)
        {
            Plant(fm.selectPlant.plant);
            mandrakeSeedsLeft--;
        }
        else if (fm.isPlanting && selectedPlant.plantName == "Mushy" && mushySeedsLeft > 0)
        {
            Plant(fm.selectPlant.plant);
            mandrakeSeedsLeft--;
        }
    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if(isPlanted || mandrakeSeedsLeft >= 0)
            {
                //Can't buy
                plot.color = unavailableColor;
            }
            else
            {
                //Can buy
                plot.color = availableColor;
            }
        }
    }

    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

    void Harvest()
    {
        Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);
        if (plant.transform.name.Contains("Mandrake"))
        {
            inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Mandrake");
        }
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
    }
}

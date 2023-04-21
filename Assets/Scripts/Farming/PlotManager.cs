using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    LetterOrders letterOrders;
    public GameObject inventoryManager;
    public AudioSource harvestSound;
    public LayerMask harvestLayers;

    public GameObject envelopeButton;
    public GameObject displayMoney;
    public GameObject mainDisplayMoney;
    public Color cancelColor = Color.red;


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
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            //We want to harvest if crop is planted
            if(plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, harvestLayers);
                if (hit && hit.transform.name.Contains("Blueberry"))
                {
                    print("you found a blueberry!");
                    inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Blueberry");
                    harvestSound.Play();
                }
                else if (hit && hit.transform.name.Contains("Mushy"))
                {
                    print("you found a Mushy!");
                    inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Mushy");
                    harvestSound.Play();

                }
                else if (hit && hit.transform.name.Contains("Mandrake"))
                {
                    print("you found a Mandrake!");
                    inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Mandrake");
                    harvestSound.Play();
                }
                Harvest();

            }
        }
        else if(fm.isPlanting && fm.plantItem.plant.buyPrice <= fm.fmMoney)
        {
            Plant(fm.plantItem.plant);
        }
    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if(isPlanted || fm.plantItem.plant.buyPrice > fm.fmMoney)
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
        inventoryManager.GetComponent<Inventory>().IncreaseIngredient(plant.sprite.name);
        print(plant.sprite.name);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;

        //fm.fmMoney = fm.fmMoney - selectedPlant.buyPrice;
        //fm.Transaction(-selectedPlant.buyPrice);

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
        envelopeButton.GetComponent<LetterOrders>().money -= newPlant.buyPrice;
        displayMoney.GetComponent<TextMeshProUGUI>().text = "$ " + envelopeButton.GetComponent<LetterOrders>().money.ToString();
        mainDisplayMoney.GetComponent<TextMeshProUGUI>().text = "$ " + envelopeButton.GetComponent<LetterOrders>().money.ToString();
        //plantItem = newPlant;
        //newPlant.GetChild(3).gameObject.GetComponent<PlantItem>().btnImage.color = cancelColor;
        fm.isPlanting = false;
        newPlant = null;
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
    }
}

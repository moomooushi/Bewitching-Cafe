using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    [SerializeField] GameObject[] rocks;
    [SerializeField] GameObject poof;
    [SerializeField] GameObject brokenRocks;
    public GameObject[] ingredients;
    [SerializeField] int amount;
    [SerializeField] AudioSource[] miningAudioSource;
    [SerializeField] LayerMask miningLayers;
    [SerializeField] GameObject inventoryManager;

    public void GenerateRocks()
    {
        for (int i = 0; i < Random.Range(3,8); i++)
        {
            Instantiate(ingredients[Random.Range(0, 3)], new Vector3(Random.Range(-6.3f, 5.3f), Random.Range(-2.5f, 3.2f), 0), Quaternion.identity);
        }
        for (int x = 0; x<13; x++)
        {
            for (int y = 0; y<8; y++)
            {
                Instantiate(rocks[Random.Range(0, 7)], new Vector3(-6.5f + x, -3f + y, 0), Quaternion.identity);
            }
            Instantiate(rocks[Random.Range(0,7)], new Vector3(Random.Range(-6.5f, 5.5f), Random.Range(-3, 3.5f), 0), Quaternion.identity);
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, miningLayers);
            if (hit && hit.transform.name.Contains("Rock"))
            {
                Instantiate(brokenRocks, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
                miningAudioSource[0].Play();
            }
            else if (hit && hit.transform.name.Contains("Skull"))
            {
                print("you found a Skull!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Skull");
                miningAudioSource[1].Play();
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Carnelian"))
            {
                print("you found Carnelian!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Carnelian");
                miningAudioSource[1].Play();
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Rose Quartz"))
            {
                print("you found Rose Quartz!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Rose Quartz");
                miningAudioSource[1].Play();
                Destroy(hit.transform.gameObject);
            }
        }

    }
}

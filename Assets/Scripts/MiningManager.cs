using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject[] ingredients;
    public int amount;
    float xPos;
    float yPos;
    public AudioSource audioSource;
    public LayerMask miningLayers;

    private void Start()
    {
        GenerateRocks();
    }

    void GenerateRocks()//start asleep?? maybe use to make rock fall when clicked
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(ingredients[Random.Range(0, 2)], new Vector3(Random.Range(-6.3f, 5.3f), Random.Range(-2.5f, 3.2f), 0), Quaternion.identity);
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
            //print(hit.transform.name);
            if (hit && hit.transform.name.Contains("Rock"))
            {
                hit.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
                hit.transform.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                Destroy(hit.transform.gameObject ,2);
                audioSource.Play();
                //hit.transform.gameObject.GetComponent<>
            }
            else if (hit && hit.transform.name.Contains("Skull"))
            {
                print("you found a Skull!");
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Carnelian"))
            {
                print("you found Carnelian!");
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Rose"))
            {
                print("you found Rose Quartz!");
                Destroy(hit.transform.gameObject);
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject[] ingredients;
    public int amount;
    private void Start()
    {
        GenerateRocks();
    }

    void GenerateRocks()//start asleep?? maybe use to make rock fall when clicked
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(ingredients[Random.Range(0, 2)], new Vector3(Random.Range(-6.3f, 5.3f), Random.Range(-2.5f, 3.2f), 0), Quaternion.identity);
        }
        for (int i = 0; i<100; i++)
        {
            Instantiate(rocks[Random.Range(0,0)], new Vector3(Random.Range(-6.5f, 5.5f), Random.Range(-3, 3.5f), 0), Quaternion.identity);
        }
    }
}

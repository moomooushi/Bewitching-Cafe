using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] private GameObject frogIngredient;
    [SerializeField] private GameObject toadIngredient;
    [SerializeField] private GameObject ingredientSpawnPoint;

    public void SpawnFrog()
    {
        Instantiate(frogIngredient, ingredientSpawnPoint.transform.position, transform.rotation);
    }
    public void SpawnToad()
    {
        Instantiate(toadIngredient, ingredientSpawnPoint.transform.position, transform.rotation);
    }
}

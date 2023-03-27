using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public void CleanUpMess()//removes leftover game object clones for transitioning
    {
        GameObject[] minerals = GameObject.FindGameObjectsWithTag("Minerals");
        foreach (GameObject mineral in minerals)
        {
            Destroy(mineral);
        }
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredients");
        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
        GameObject[] Mandrake = GameObject.FindGameObjectsWithTag("Ingredients");
        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
    }
}

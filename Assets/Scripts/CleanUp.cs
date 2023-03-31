using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public void CleanUpMess(string where)//removes leftover game object clones for transitioning
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
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Catchables");
        foreach (GameObject butterfly in butterflies)
        {
            Destroy(butterfly);
        }
        //GameObject[] potions = GameObject.FindGameObjectsWithTag("Potion");
        //if (where == "Mine")
        //{
        //    foreach (GameObject potion in potions)
        //    {
        //        potion.SetActive(false);
        //    }
        //}
        //else
        //{
        //    foreach (GameObject potion in potions)
        //    {
        //        potion.SetActive(true);
        //    }
        //}
    }
}

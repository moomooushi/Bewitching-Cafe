using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientIdentifier : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Frog") && collision.gameObject.CompareTag("Toad")) 
        {
            Debug.Log("both exist in the cauldron");
            //Destroy(GameObject.FindWithTag("Frog"));
            //Destroy(GameObject.FindWithTag("Toad"));
        }       
    }

}

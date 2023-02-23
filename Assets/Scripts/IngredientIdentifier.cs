using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientIdentifier : MonoBehaviour
{
    [SerializeField] PotionData recipe;
    [SerializeField] List<Ingredient> containedIngredients;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // You might wanna check if the ingredient instance is already in the list, and return out if it is
        if(collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            if (containedIngredients.Find(i => i == ingredient)) return;
            containedIngredients.Add(ingredient);
        }
        //if (collision.gameObject.CompareTag("Frog") && collision.gameObject.CompareTag("Toad")) 
        //{
        //    Debug.Log("both exist in the cauldron");
        //    //Destroy(GameObject.FindWithTag("Frog"));
        //    //Destroy(GameObject.FindWithTag("Toad"));
        //}       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            containedIngredients.Remove(ingredient);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientIdentifier : MonoBehaviour
{
    [SerializeField] List<PotionData> recipes;
    [SerializeField] List<Ingredient> containedIngredients;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // You might wanna check if the ingredient instance is already in the list, and return out if it is
        if(collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            if (containedIngredients.Find(i => i == ingredient)) return;
            containedIngredients.Add(ingredient);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            containedIngredients.Remove(ingredient);
        }
    }

}

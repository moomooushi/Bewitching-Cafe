using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ingredients;
using UnityEngine;
using Abstracts;
using Events;
using Interfaces;
using ScriptableObjects;

public class IngredientIdentifier : Receptacle
{
    [SerializeField] List<PotionData> recipes;
    [SerializeField] List<Ingredient> containedIngredients;

    private void OnEnable()
    {
        GameEvents.OnDestroyCauldronItemsEvent += DestroyItemsInCauldron;
    }    
    
    private void OnDisable()
    {
        GameEvents.OnDestroyCauldronItemsEvent -= DestroyItemsInCauldron;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        // You might wanna check if the ingredient instance is already in the list, and return out if it is
        if(collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            if (containedIngredients.Find(i => i == ingredient)) return;
            containedIngredients.Add(ingredient);
            // invoke event, and send contained ingredients to potion manager. event thats expecting a list of ingredients.
            
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ingredient>(out Ingredient ingredient))
        {
            containedIngredients.Remove(ingredient);
        }
    }

    void DestroyItemsInCauldron()
    {
        List<Transform> children = this.GetComponentsInChildren<Transform>().ToList(); // gets all transforms in cauldron and converts it to lists
        foreach (var i in children)
        {
            var isDestroyable = i.gameObject.TryGetComponent(out IDestroyable destroyable);
            if (isDestroyable)
                destroyable.DoDestroy();
        }
    }
}

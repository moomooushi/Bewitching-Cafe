using System.Collections;
using System.Collections.Generic;
using Ingredients;
using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        // Cauldron events
        public delegate void DestroyCauldronItems();

        public static DestroyCauldronItems OnDestroyCauldronItemsEvent;
        
        // Other events
        public delegate void WhenIngredientDestroyed();

        public static WhenIngredientDestroyed OnIngredientDestroyedEvent;
        
        // Ingredients stuff
        public delegate void IngredientAdded(Ingredient ingredient);

        public delegate void IngredientRemoved(Ingredient ingredient);
        
        public static IngredientAdded OnIngredientEnterCauldron;
        public static IngredientRemoved OnIngredientExitCauldron;
    }
}
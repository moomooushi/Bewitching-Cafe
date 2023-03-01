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
        
        // send ingredients to potion manager

        public delegate void UpdateList(List<Ingredient> list);
        
        public static UpdateList onSendListEvent;
        // in manager subscribe to onSendListEvent. 
    }
}
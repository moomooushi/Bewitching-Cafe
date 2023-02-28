using System.Collections;
using System.Collections.Generic;
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
    }
}
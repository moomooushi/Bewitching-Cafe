using System.Collections.Generic;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PotionData", menuName = "Potions/New Potion")]
    public class PotionData : ScriptableObject
    {
        [SerializeField] private string potionName;
        [SerializeField] Sprite sprite;
        [SerializeField] List<IngredientData> recipe; // HashSet makes every item different.
    }
}
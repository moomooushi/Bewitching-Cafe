using System.Collections.Generic;
using Core;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PotionData", menuName = "Potions/New Potion")]
    public class PotionData : ScriptableObject
    {
        [SerializeField] private string potionName;
        public Sprite sprite;
        [SerializeField] List<IngredientData> recipe; // HashSet makes every item different.

        public Potion potionPrefab;

        public List<IngredientData> Recipe => recipe;
    }
}
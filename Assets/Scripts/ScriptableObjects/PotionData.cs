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
        public int howManyPotionsExist = 0; // Use this for the UI sometime perchance!?!? Would be epic!

        public Potion potionPrefab;

        public Vector2 spawnPosition = new Vector2();

        public List<IngredientData> Recipe => recipe;
    }
}
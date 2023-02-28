using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Ingredients;

[CreateAssetMenu(fileName = "PotionData", menuName = "Potions/New Potion")]
public class PotionData : ScriptableObject
{
    [SerializeField] private string potionName;
    [SerializeField] Sprite sprite;
    [SerializeField] List<IngredientData> recipe;
}
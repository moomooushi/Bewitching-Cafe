using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionData", menuName = "Potions/New Potion")]
public class PotionData : ScriptableObject
{
    [SerializeField] private string potionName;
    [SerializeField] Sprite sprite;
    [SerializeField] List<IngredientData> recipe;
}
using UnityEngine;

namespace ScriptableObjects.Ingredients
{
    
    [CreateAssetMenu(fileName = "Ingredients", menuName = "Ingredients/New Ingredient")]
    public class IngredientData : ScriptableObject
    {
        public new string name;
        public Sprite sprite;
        public float ingredientPrice;

        public int amountOfIngredient;
    }

}

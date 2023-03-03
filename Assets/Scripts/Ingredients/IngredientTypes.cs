using UnityEngine;
using ScriptableObjects.Ingredients;

namespace Ingredients {
[CreateAssetMenu(fileName = "IngredientTypesList_", menuName = "Ingredients/New Ingredients List")]
public class IngredientTypes : ScriptableObject
{
    public IngredientData[] list;
}

}


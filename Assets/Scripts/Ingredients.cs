using UnityEngine;

[CreateAssetMenu(fileName = "Ingredients", menuName = "Ingredients/New Ingredient")]
public class Ingredients : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public float ingredientPrice;
}

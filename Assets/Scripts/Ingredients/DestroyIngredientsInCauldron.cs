using UnityEngine;

namespace Ingredients
{
    public class DestroyIngredientsInCauldron : MonoBehaviour
    {
        private GameObject[] ingredients;

        public void DestroyAllIngredients()
        {
            ingredients = GameObject.FindGameObjectsWithTag("Ingredients");

            foreach (GameObject ingredient in ingredients)
            {
                Destroy(ingredient);
            }
        }
    }
}

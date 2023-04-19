using System;
using UnityEngine;

namespace Ingredients
{
    public class DestroyIngredientsOnFloor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Ingredients"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}

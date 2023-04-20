using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients
{
    public class DestroyIngredientsOnFloor : MonoBehaviour
    {
        public List<GameObject> itemsOnGround = new List<GameObject>(); 
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject)
            {
                itemsOnGround.Add(collision.gameObject);
            }

            foreach (GameObject items in itemsOnGround)
            {
                items.layer = LayerMask.NameToLayer("Catchable");
            }
        }
    }
}

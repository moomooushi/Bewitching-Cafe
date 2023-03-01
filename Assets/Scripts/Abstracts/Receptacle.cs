using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using Ingredients;

namespace Abstracts
{
    public class Receptacle : MonoBehaviour
    {
        protected void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.GetComponent<Ingredient>())
            {
                col.transform.parent = transform;
            }
        }
    }
}


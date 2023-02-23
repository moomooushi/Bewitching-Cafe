using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Start is called before the first frame update
    [field: SerializeField] public IngredientData Data { get; private set; }
}

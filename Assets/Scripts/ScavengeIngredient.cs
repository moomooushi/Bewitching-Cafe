using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Everything here is temporary and subject to change.
public class ScavengeIngredient : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void IngredientName(Button btn)
    {
        Debug.Log(btn.name);
        text.SetText("You have grabbed " + btn.name + "!");
        Destroy(btn.gameObject);
    }
}

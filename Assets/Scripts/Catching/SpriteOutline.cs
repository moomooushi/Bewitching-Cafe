using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup canvasGroup;
    private bool hovered;
    
    // [SerializeField] private float timer;
    // [SerializeField] private bool lit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        print("Mouse hovered");
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.2f;
        print("Mouse unhovered");
        hovered = false;
    }
    
    
}
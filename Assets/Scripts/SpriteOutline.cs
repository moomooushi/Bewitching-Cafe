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

    [SerializeField] private float duration;
    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        print("Mouse hovered");
        StopAllCoroutines();
        StartCoroutine(Transition(0.2f, 1f, duration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.2f;
        print("Mouse unhovered");
        StopAllCoroutines();
        StartCoroutine(Transition(1f, .2f, duration));
    }

    IEnumerator Transition(float startingValue, float endingValue, float duration)
    {
        float progress = 0;
        while (progress < 1)
        {
            progress += Time.deltaTime / duration;
            var transparency = Mathf.Lerp(startingValue, endingValue, progress);
            canvasGroup.alpha = transparency;
            //Debug.Log(progress);
            //Debug.Log(canvasGroup.alpha);
            yield return null;
        }
    }
    
}
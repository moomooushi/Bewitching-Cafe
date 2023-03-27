using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSigilFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private bool lightUp;

    void Update()
    {
        if (canvasGroup.alpha == 0)
        {
            lightUp = true;
        }
        if (canvasGroup.alpha == 1)
        {
            lightUp = false;
        }
        if (lightUp == true)
        {
            canvasGroup.alpha += 0.3f * Time.deltaTime;
        }
        else if (lightUp == false)
        {
            canvasGroup.alpha -= 0.4f * Time.deltaTime;
        }
    }
}

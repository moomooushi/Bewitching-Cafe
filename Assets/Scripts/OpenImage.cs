using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenImage : MonoBehaviour
{
    public GameObject Image;

    public void OpenBook()
    {
        if (Image != null)
        {
            Image.SetActive(true);
        }
    }
}

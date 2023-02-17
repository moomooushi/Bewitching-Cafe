using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseImage : MonoBehaviour
{
    public GameObject Image;

    public void CloseBook()
    {
        if (Image != null)
        {
            bool isActive = Image.activeSelf;
            Image.SetActive(!isActive);
        }
    }
}

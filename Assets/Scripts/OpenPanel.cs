using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public Image closedEnvelope;
    public Sprite openEnvelope;

    public void OpenEnvelope()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void ChangeImage()
    {
        closedEnvelope.sprite = openEnvelope;
    }
}

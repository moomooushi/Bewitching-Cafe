using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    [SerializeField] AudioSource sparkleAudio;

    void OnMouseEnter()
    {
        sparkleAudio.Play();
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        sparkleAudio.Stop();
        transform.GetChild(0).gameObject.SetActive(false);
    }
}

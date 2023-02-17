using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public void PlayCauldronBubbles()
    {
        GetComponent<AudioSource>().Play();
    }

    public void PlayCatMeow()
    {
        GetComponent<AudioSource>().Play();
    }

    public void PlayEnvelopeSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void PlayEnvelopeCloseSound()
    {
        GetComponent<AudioSource>().Play();
    }
}

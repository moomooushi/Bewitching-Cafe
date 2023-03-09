using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatDialogue : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public string message;
    public float delay = 0.1f;
    public float visibleDuration = 2f;
    public AudioClip soundEffect;

    private int currentIndex = 0;
    private float lastTime;
    private float visibleTime;
    private AudioSource audioSource;
    private bool isPlayingSound;

    private void Start()
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        textMesh.text = "";
        lastTime = Time.time;
        visibleTime = Time.time;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (currentIndex >= message.Length)
        {
            // Check if the text has been visible for the specified duration.
            if (Time.time - visibleTime >= visibleDuration)
            {
                // Disable the TextMeshPro text when the visible duration is over.
                textMesh.enabled = false;
            }
            return;
        }

        if (Time.time - lastTime >= delay)
        {
            lastTime = Time.time;
            textMesh.text += message[currentIndex];
            currentIndex++;

            if (!isPlayingSound)
            {
                // Play the sound effect at the start of the sentence.
                if (message[currentIndex - 1] == ' ' && soundEffect != null)
                {
                    audioSource.PlayOneShot(soundEffect);
                    isPlayingSound = true;
                }
            }
        }

        // Update the visible time every frame while the text is still being generated.
        visibleTime = Time.time;
    }
}


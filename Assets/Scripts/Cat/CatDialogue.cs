using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CatMessage
{
    public string message;
    public float visibleDuration = 2f;
    public AudioClip soundEffect;
}

public class CatDialogue : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public List<CatMessage> messages;
    public float messageDelay = 1f;

    private int currentMessageIndex = 0;
    private AudioSource audioSource;

    public void StartGame()
    {
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        audioSource = GetComponent<AudioSource>();

        if (messages.Count > 0)
        {
            DisplayCurrentMessage();
        }
    }

    private void DisplayCurrentMessage()
    {
        CatMessage currentMessage = messages[currentMessageIndex];
        textMesh.text = currentMessage.message;

        if (audioSource != null && currentMessage.soundEffect != null)
        {
            audioSource.PlayOneShot(currentMessage.soundEffect);
        }

        float displayTime = currentMessage.visibleDuration;
        Invoke("HideCurrentMessage", displayTime);
    }

    private void HideCurrentMessage()
    {
        textMesh.enabled = false;
        Invoke("DisplayNextMessage", messageDelay);
    }

    private void DisplayNextMessage()
    {
        currentMessageIndex++;

        if (currentMessageIndex >= messages.Count)
        {
            // Disable the TextMeshPro text when all messages have been displayed.
            textMesh.enabled = false;
            return;
        }

        textMesh.enabled = true;
        DisplayCurrentMessage();
    }
}



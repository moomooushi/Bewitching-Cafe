using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDialogue : MonoBehaviour
{
    public float minTimeBetweenMessages = 1f; // Minimum time between messages
    public float maxTimeBetweenMessages = 5f; // Maximum time between messages
    public TextMeshProUGUI textMeshPro; // Reference to TextMeshProUGUI component

    public string[] messages;
    private float nextMessageTime; // Time when the next message should be displayed

    void Start()
    {
        InvokeRepeating("SendRandomMessage", 5, 5);
    }

    void Update()
    {


    }

    void SendRandomMessage() {
         nextMessageTime = Time.time + Random.Range(minTimeBetweenMessages, maxTimeBetweenMessages); // Set the time for the first message

        if (Time.time >= nextMessageTime) // Check if it's time to display a message
        {
            string message = messages[Random.Range(0, messages.Length)]; // Choose a random message from the array
            textMeshPro.text = message; // Set the TextMeshProUGUI component's text to the chosen message
            nextMessageTime = Time.time + Random.Range(minTimeBetweenMessages, maxTimeBetweenMessages); // Set the time for the next message
        }
    }
}

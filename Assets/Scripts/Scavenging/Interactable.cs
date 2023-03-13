using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scavenging
{
    public class Interactable : MonoBehaviour
    {
        public bool isInRange;
        public KeyCode interactKey;
        public UnityEvent interactAction;

        private void Update()
        {
            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactAction.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log("Player in range");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                Debug.Log("Player out of range");
            }
        }
    }
}

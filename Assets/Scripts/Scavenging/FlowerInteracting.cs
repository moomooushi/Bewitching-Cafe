using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace Scavenging
{
    public class FlowerInteracting : MonoBehaviour
    {
        [SerializeField] private int randNumber;
        private bool interactionActivated = false;
        [SerializeField] private GameObject[] randomIngredientAdded;
        [SerializeField] private TextMeshProUGUI itemReceivedText;

        public void FoundItem()
        {
            if (Input.GetKey(KeyCode.E))
                randNumber = Random.Range(1, 50);


            if (!interactionActivated)
            {
                if (randNumber <= 20)
                {
                    StartCoroutine(NoItemFound());
                }
                else if (randNumber >= 20)
                {
                    StartCoroutine(ItemFound());
                }
            }
            interactionActivated = true;

        }

        IEnumerator NoItemFound()
        {
            itemReceivedText.SetText("Looks like nothing was there...");
            yield return new WaitForSeconds(2f);
            itemReceivedText.SetText("");
            interactionActivated = false;
        }

        IEnumerator ItemFound()
        {            
            int index = Random.Range(0, randomIngredientAdded.Length);
            string nameChange = randomIngredientAdded[index].name.Replace("Amount", "");
            int.TryParse(randomIngredientAdded[index].GetComponent<TextMeshProUGUI>().text, out int number);
            itemReceivedText.SetText("You found a " + nameChange);
            number += 1;
            randomIngredientAdded[index].GetComponent<TextMeshProUGUI>().text = number.ToString();
            yield return new WaitForSeconds(2f);
            itemReceivedText.SetText("");
            interactionActivated = false;
        }
    }
}

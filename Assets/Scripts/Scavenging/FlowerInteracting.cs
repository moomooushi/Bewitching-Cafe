using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

namespace Scavenging
{
    public class FlowerInteracting : MonoBehaviour
    {
        [SerializeField] private int randNumber;
        private bool interactionActivated = false;
        [SerializeField] private GameObject[] randomIngredientAdded;
        [SerializeField] private TextMeshProUGUI itemReceivedText;
        [SerializeField] private TextMeshProUGUI potionReceivedText;
        


        [Header("Takes care of potion finding")]
        [SerializeField] private List<GameObject> potionRecipeUnlocks;
        [SerializeField] private int randNumberForPotion;
        [SerializeField] private AudioClip ingredientFind;
        [SerializeField] private AudioClip potionFind;


        public void FoundItem()
        {
            if (Input.GetKey(KeyCode.E))
            {
                randNumber = Random.Range(1, 50);
                randNumberForPotion = Random.Range(1, 200);
            }



            if (!interactionActivated)
            {
                if (randNumber <= 20)
                {
                    StartCoroutine(NoItemFound());
                }
                else if (randNumber >= 20)
                {
                    StartCoroutine(ItemFound());
                    if (randNumberForPotion >= 80 && randNumberForPotion <= 100) 
                    {
                        StartCoroutine(PotionFound());
                    }
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
            AudioSource.PlayClipAtPoint(ingredientFind, transform.position, 0.8f);
            yield return new WaitForSeconds(2f);
            itemReceivedText.SetText("");
            interactionActivated = false;
        }

        IEnumerator PotionFound() 
        {
            int potionIndex = Random.Range(0, potionRecipeUnlocks.Count);
            string nameChangePotion = potionRecipeUnlocks[potionIndex].name.Replace("Description", "Potion Recipe!");
            potionRecipeUnlocks[potionIndex].SetActive(true);
            potionReceivedText.SetText("Wow! You found a(n) " + nameChangePotion);
            AudioSource.PlayClipAtPoint(potionFind, transform.position, 0.55f);
            yield return new WaitForSeconds(2f);
            potionReceivedText.SetText("");
            potionRecipeUnlocks.Remove(potionRecipeUnlocks[potionIndex]);
        }
    }
}

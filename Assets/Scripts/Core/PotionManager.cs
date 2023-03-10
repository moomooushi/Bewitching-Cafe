using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Events;
using Ingredients;
using ScriptableObjects;
using ScriptableObjects.Ingredients;
using TMPro;


namespace Core
{
    public class PotionManager : MonoBehaviour
    {
        [SerializeField] private List<IngredientData> containedIngredients;
        [SerializeField] private PotionList potions;
        [SerializeField] private Potion potionItemPrefab;
        

        [Header("Updating Counters for Potions")]
        public TMP_Text healthPotCounter;
        public TMP_Text lovePotCounter;
        public TMP_Text poisonPotCounter;


        SpriteRenderer sr;
        
        private void OnEnable()
        {
            GameEvents.OnIngredientEnterCauldron += Add;
            GameEvents.OnIngredientExitCauldron += Remove;
        }
        private void OnDisable()
        {
            GameEvents.OnIngredientEnterCauldron -= Add;
            GameEvents.OnIngredientExitCauldron -= Remove;
        }

        public void Add(Ingredient ingredient)
        {
            containedIngredients.Add(ingredient.IngredientData);
            MixPotions();
        }

        public void Remove(Ingredient ingredient)
        {
            IngredientData i = containedIngredients.Find(i => i == ingredient.IngredientData);
            containedIngredients.Remove(i);
        }

        IEnumerator DelayMix(PotionData potionData)
        {
            yield return new WaitForSeconds(.25f);
            var potionObject = Instantiate(potionItemPrefab, potionData.spawnPosition, Quaternion.identity);
            potionObject.GetComponent<Potion>().PotionType = potionData;
            //potionData.howManyPotionsExist += 1;
            //healthPotCounter.SetText(potionData.howManyPotionsExist.ToString());
            //lovePotCounter.SetText(potionData.howManyPotionsExist.ToString());
            //poisonPotCounter.SetText(potionData.howManyPotionsExist.ToString());
        }

        public void MixPotions()
        {
            var cauldronIngredientNames = containedIngredients.Select(x => x.name).ToList();
            var filterPotions = potions.ListOfPotions
                .Where(x => x.Recipe.All(y => cauldronIngredientNames.Contains(y.name))).ToList();
            var potionToMix = filterPotions.Count > 0 ? filterPotions[0] : null;

            if (potionToMix != null)
            {
                potionItemPrefab = potionToMix.potionPrefab;
                StartCoroutine(DelayMix(potionToMix));
                cauldronIngredientNames.Clear();
                filterPotions.Clear();
                GameEvents.OnDestroyCauldronItemsEvent?.Invoke();
                containedIngredients.Clear();
            }
        }
    }
}

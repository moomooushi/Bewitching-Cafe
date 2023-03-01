using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "_PotionList", menuName = "Potions/New Potion List")]
    public class PotionList : ScriptableObject
    {
        [SerializeField] private List<PotionData> listOfPotions;

        public List<PotionData> ListOfPotions
        {
            get => listOfPotions;
            private set => listOfPotions = value;
        }
    }
}

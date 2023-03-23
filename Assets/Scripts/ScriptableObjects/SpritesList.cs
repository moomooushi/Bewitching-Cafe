using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects 
{
    [CreateAssetMenu(fileName = "SpritesList", menuName = "New Scav Pot/New ScavPots List")]
    public class SpritesList : ScriptableObject
    {
        public List<GameObject> scavPotsList = new();
    }
}


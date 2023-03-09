using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Critters;


namespace ScriptableObjects {
[CreateAssetMenu(fileName = "CritterList", menuName = "Critters/New Critter List")]
    public class CritterList : ScriptableObject
    {
        public List<CritterData> critterList = new();
    }

}

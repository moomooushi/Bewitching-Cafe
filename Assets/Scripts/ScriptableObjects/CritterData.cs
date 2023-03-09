using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Critters {

    [CreateAssetMenu(fileName = "CritterData", menuName ="Critters/New Critter")]
    public class CritterData : ScriptableObject
    {
        public string critterName;
        public GameObject critterPrefab;

        public Vector2 spawnPosition = new Vector2();

        public float walkSpeed;
    }
}



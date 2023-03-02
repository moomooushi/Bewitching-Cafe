using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects 
{
    [CreateAssetMenu(fileName = "SpritesList", menuName = "New Sprite/New Sprite List")]
    public class SpritesList : ScriptableObject
    {
        public List<Sprite> spriteList = new();
    }
}


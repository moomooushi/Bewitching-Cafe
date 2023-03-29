using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.26f);
    }
}

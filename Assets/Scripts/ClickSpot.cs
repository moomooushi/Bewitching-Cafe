using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpot : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorial.GetComponent<Tutorial>().stage ++;
        }
    }
}

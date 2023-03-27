using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRocks : MonoBehaviour
{
    [SerializeField]
    GameObject[] pebbles;

    private void Start()
    {
        Destroy(gameObject, 10);//prevent clutter
    }
    void Update()
    {
        foreach (GameObject pebble in pebbles)//slowly making the pebbles small so its less jarring when they destroy
        {
            pebble.transform.localScale = new Vector3(pebble.transform.localScale.x - 0.003f * Time.deltaTime, pebble.transform.localScale.y - 0.003f * Time.deltaTime, 0);
        }
    }
}

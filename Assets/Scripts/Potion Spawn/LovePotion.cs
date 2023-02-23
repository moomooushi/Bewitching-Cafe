using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovePotion : MonoBehaviour
{
    public GameObject lovePotion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkCrystal")
        {
            Instantiate(lovePotion, new Vector3(-4.19f, 2.9f, 0.0056f), transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

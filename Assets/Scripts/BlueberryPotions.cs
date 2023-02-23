using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberryPotions : MonoBehaviour
{
    public GameObject healingPotion;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            Instantiate(healingPotion, new Vector3(-4.19f, 2.5f, 0.0056f), transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotion : MonoBehaviour
{

    public GameObject poisonPotion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            Instantiate(poisonPotion, new Vector3(-1.19f, 2.9f, 0.0056f), Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

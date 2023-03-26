using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovement : MonoBehaviour
{
    public float speed = 5f;

    public float minX;

    public float maxX;

    public float minY;

    public float maxY;

    private Collider2D movementAreaCollider;
    // Start is called before the first frame update
    void Start()
    {
        movementAreaCollider = GetComponentInParent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // generate a new random position
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 targetPosition = new Vector2(randomX, randomY);

        // calculate direction and set velocity
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // if collision is with movement area, continue moving
        if (col.collider == movementAreaCollider)
        {
            return;
        }
        // otherwise, stop moving
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}

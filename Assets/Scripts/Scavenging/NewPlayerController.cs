using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed = 13f;
    Vector2 motionVector;
    Animator animator;

    private bool isMoving;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
            motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            animator.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.velocity = motionVector * speed * Time.deltaTime;
    }
}

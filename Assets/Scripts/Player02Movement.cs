﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Movement : MonoBehaviour {

    Rigidbody2D Rigidbody2D;
    BoxCollider2D BoxCollider2D;
    bool Grounded;

    public float MoveSpeed = 10f;
    public float JumpVelocity = 10f;
    public float FallMultiplyer = 3.5f;
    public float LowJumpMultiplyer = 2f;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Grounded = false;
    }

    void Update()
    {
        Movement();
        BetterJump();
    }

    // L+R with Vector2.
    // Jump with Rigidbody2D. 
    // Can only jump once when grounded.
    // Rigidbody Z Constraint, locked.
    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded == true)
        {
            Rigidbody2D.velocity = Vector2.up * JumpVelocity;
            Grounded = false;
        }
    }

    // Less floaty when jumping.
    void BetterJump()
    {
        if (Rigidbody2D.velocity.y < 0)
        {
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplyer - 1) * Time.deltaTime;
        }
        else if (Rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {   // Jump increases longer holds down Jump Button.
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplyer - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        { Grounded = true; }
    }
}
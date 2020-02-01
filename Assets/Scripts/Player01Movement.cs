using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Movement : MonoBehaviour {

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
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
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
        if (collision.gameObject.tag == "Ground")
        { Grounded = true; }



        if (collision.gameObject.tag == "Platforms")
        {
            Debug.Log("Collision Occur");
            Grounded = true;


            Color color = collision.collider.gameObject.GetComponent<SpriteRenderer>().color;

            if (color == Color.red)
            {
                Debug.Log("Colour is Red");
                //Collision IS DISABLED
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            }
            else if (color == Color.blue)
            {
                Debug.Log("Colour is blue");
                //Collision IS ENABLED
            }
            else
            {//Mainly for damage control and/or tutorial

                Debug.Log("COLOUR IS NOTHING");
                //SET COLOR TO BLUE
               collision.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            }
            //Checking Colour; need spriterenderer via collisionobject getcomponent




        }
    }

}



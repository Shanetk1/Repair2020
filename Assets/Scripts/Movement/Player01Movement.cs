using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Movement : MonoBehaviour {

    ManagerGame ManagerGame;
    Rigidbody2D Rigidbody2D;
    BoxCollider2D BoxCollider2D;
    [SerializeField] bool Grounded;

    //Animations
    public Animator myAnim;

    public float MoveSpeed = 10f;
    public float JumpVelocity = 10f;
    public float FallMultiplyer = 3.5f;
    public float LowJumpMultiplyer = 2f;

    private bool doubleJump = false; //Handled internally
    private float horizMove = 0.0f;

    private bool isFacingRight = true;

    public bool getisGround() { return Grounded; }


    void Start()
    {
        ManagerGame = GameObject.Find("ManagerGame").GetComponent<ManagerGame>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Grounded = false;
    }

    void Update()
    {   // Allowing movement when not dead.
        if (ManagerGame.State != ManagerGame.Game.Dead)
        {
            Movement();
            BetterJump();

        }
    }

    // L+R with Vector2.
    // Jump with Rigidbody2D. 
    // Can only jump once when grounded.
    // Rigidbody Z Constraint, locked.
    void Movement()
    {
        horizMove = Mathf.Abs(Input.GetAxisRaw("Horizontal") * MoveSpeed);
        //^ Could be used for left right movement but I need it for speed since we used Translate
        myAnim.SetFloat("Speed", horizMove);

        if (Input.GetKeyDown(KeyCode.W) && Grounded == false && doubleJump == true)
        {
            //Expend Double Jump!
            Debug.Log("Double Jumping");
            Rigidbody2D.velocity = Vector2.up * JumpVelocity;
            doubleJump = false;
        }
        


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

            if (isFacingRight)
            {
                flip();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

            if (!isFacingRight)
            {
                flip();
            }

        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true && Rigidbody2D.velocity.y == 0.0f)
        {
            myAnim.SetBool("isJump", true);
            
            Rigidbody2D.velocity = Vector2.up * JumpVelocity;
            Grounded = false;
        }
        if (Rigidbody2D.velocity.y == 0.0f)//Sometimes grounded can get bugged out VIA Physics.IgnoreCollision This is the solution
        {
            Grounded = true;
        }//THIS IS RISKY BECAUSE THIS COULD TRIGGER IN THE AIR AT THE PERFECT TIME


        if (Grounded == true && Rigidbody2D.velocity.y == 0.0f)
        {
            myAnim.SetBool("isJump", false);
        }


        
    }

    // Less floaty when jumping.
    void BetterJump()
    {
        if (Rigidbody2D.velocity.y < 0)
        {
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplyer - 1) * Time.deltaTime;
        }
        else if (Rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {   // Jump increases longer holds down Jump Button.
            Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplyer - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Powerup")
        {
            Debug.Log("Hit powerup");
            Destroy(collision.collider.gameObject);
            doubleJump = true;
            
        }

    }

    // When exits PlayArea, destroyed obj and changes GameState.
    /*  void OnTriggerExit2D(Collider2D collision)
      {
          Debug.Log(collision.gameObject.tag);
          if (collision.gameObject.tag != "Platforms")
          {
              Destroy(this.gameObject);
              ManagerGame.State = ManagerGame.Game.Dead;
          }
      }*/

    private void flip()
    {
        isFacingRight = !isFacingRight;

        //Basically flipping the character 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
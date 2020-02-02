using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //**This script Disables/Enables isTrigger of the Platform Collider based on player COLOUR**//


    private void Start()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        //On trigger checks the colour of the object hit and will enable disable our PARENT2D OBJ 

        
        float RED = collision.gameObject.GetComponent<SpriteRenderer>().color.r;//Grabs Object that hit us so our PLAYER
        float BLUE = collision.gameObject.GetComponent<SpriteRenderer>().color.b;
        Color col2 = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;//Grabs the platforms colour


        if (RED >= 1.0f && col2 == Color.red || BLUE >= 1.0f && col2 == Color.blue )
        {
            


            gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
            //If same colour ensure our ACTUAL COLLIDER is not an isTrigger
        }
        else
        {
            gameObject.transform.parent.GetComponentInParent<BoxCollider2D>().isTrigger = true;
            //If not same colour ensure our ACTUAL COLLIDER is an isTrigger
            //This is set BEFORE COLLISION CAN OCCUR OR MAY OCCUR

        }

        
    }



    private bool stay = false; //A switch basically that tells us the player has sat or stayed at this object for enough time to allow a colour change


    private void Update()
    {
        //If our stay is TRUE ANDDDD

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //When we leave this trigger
        //Get colour of PLAYER because if STAY IS TRUE we know PLAYER.COLOUR == PLATFORM.COLOUR 

        Color playerColour = collision.gameObject.GetComponent<SpriteRenderer>().color;
        if (stay)
        {
            SpriteRenderer platColour = gameObject.transform.parent.GetComponent<SpriteRenderer>();
            if (playerColour.r >= 1.0f)
            {
                platColour.color = Color.blue;
            }
            else if (playerColour.b >= 1.0f)//Safer if than using else
            {
                //Turn Platform Red
                platColour.color = Color.red;
            }
            stay = false;
        }
    }



    //Our logic which tells the platform whether the block can change colours or not
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Rigidbody2D myBody = collision.gameObject.GetComponent<Rigidbody2D>();

        Player01Movement pScript =  myBody.gameObject.GetComponent<Player01Movement>();
/*
        if ()
        {
            pScript.getisGround();
        }
        */

        BoxCollider2D myBox = gameObject.transform.parent.GetComponent<BoxCollider2D>();
        if (myBody != null)//Meaning this IS A PLAYER
        {
            if (myBox != null && myBox.isTrigger == false)
            {
                if (myBody.velocity.y == 0.0f)
                {
                    //Baiscally if Our PLAYER 
                    stay = true;
                }
            }
        }
    }

}

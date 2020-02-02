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
        //Change colour to obj name
        //Player1 is RED //Player2 is BLUE

        string myPlayer = collision.gameObject.name;//Our Player Name


        float RED = collision.gameObject.GetComponent<SpriteRenderer>().color.r;//Grabs Object that hit us so our PLAYER
        float BLUE = collision.gameObject.GetComponent<SpriteRenderer>().color.b;
        Color col2 = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;//Grabs the platforms colour


        if (myPlayer.Contains("Player1"))
        {
            if (col2 == Color.red)
            {
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;

            }
            else
            {
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = true;
            }//Meaning Color of our platform is BLUE

        }
        else if (myPlayer.Contains("Player2"))
        {
            if (col2 == Color.blue)
            {
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;

            }
            else
            {
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = true;
            }//Meaning Color of our platform is BLUE

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

        string player = collision.gameObject.name;
        if (stay)
        {
            SpriteRenderer platColour = gameObject.transform.parent.GetComponent<SpriteRenderer>();
            if (player.Contains("Player1"))//Player is Red
            {
                platColour.color = Color.blue;
            }
            else if (player.Contains("Player2"))//Player is Blue
            {
                platColour.color = Color.red;
            }
            stay = false;
        }
    }



    //Our logic which tells the platform whether the block can change colours or not
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Rigidbody2D myBody = collision.gameObject.GetComponent<Rigidbody2D>();
        BoxCollider2D myBox = gameObject.transform.parent.GetComponent<BoxCollider2D>();
        if (myBody != null)//Meaning this IS A PLAYER
        {
            if (myBox != null && myBox.isTrigger == false)
            {
                if (myBody.velocity.y == 0.0f)
                {

                    stay = true;
                }
            }
        }
    }

}

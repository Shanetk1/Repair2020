using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //**This script Disables/Enables isTrigger of the Platform Collider based on player COLOUR**//

    private BoxCollider2D myBox;

    void Start()
    {
        myBox = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //On trigger checks the colour of the object hit and will enable disable our PARENT2D OBJ 

        Color col = collision.gameObject.GetComponent<SpriteRenderer>().color;//Grabs Object that hit us
        Color col2 = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;//Grabs 

        if (col == col2)
        {

            gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
            //If same colour ensure our ACTUAL COLLIDER is not an isTrigger
        }
        else
        {
            
            gameObject.transform.parent.GetComponentInParent<BoxCollider2D>().isTrigger = true;
            //If not same colour ensure our ACTUAL COLLIDER is an isTrigger

        }

        
    }

}

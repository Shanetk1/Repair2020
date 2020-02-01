using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLeave : MonoBehaviour
{
    //**This Script Creates the colour change of the platform when player jumps off**



    private int count = 0;
    private bool stay = false; //A switch basically that tells us the player has sat or stayed at this object for enough time to allow a colour change

    private void OnTriggerExit2D(Collider2D collision)
    {
        //When we leave this trigger
        Color col = collision.gameObject.GetComponent<SpriteRenderer>().color;//Get colour of collided object (Player)
        Color col2 = gameObject.transform.parent.GetComponent<SpriteRenderer>().color; //Get colour of our platform (Platform)


        if (col == col2 && stay)
        {
            //This has to happen for landing to occur so this is only where color change happens
            if (col == Color.red)
            {
                gameObject.GetComponentInParent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                gameObject.GetComponentInParent<SpriteRenderer>().color = Color.red;
            }
            stay = false;
           
        }
    }

    void setStay()
    {
        stay = true;
        count = 0;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        count += 1;
        if (count >= 80)
        {
            Debug.Log("Execute");
            setStay();   
        }

    }


}

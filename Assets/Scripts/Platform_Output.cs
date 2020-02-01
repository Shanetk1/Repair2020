using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Output : MonoBehaviour
{
    // Start is called before the first frame update
    public Platform myPlat;
    

    private SpriteRenderer mySprite;
    void Start()
    {
        //NECESSARY FOR COLOUR CHANGE
        mySprite = GetComponent<SpriteRenderer>();




        if (myPlat.isPlayer1)
        {
            mySprite.color = Color.red;

        }
        else
        {
            mySprite.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

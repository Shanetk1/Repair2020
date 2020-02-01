using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("need to fix")]
    public Transform Target;
    // doing P2 for now. need to change so there's a gameobject in 
    // bottom of screen because there's 2 players.
    // ^ once done that, can use that GO as point for borders, height, death, and clouds.
    //     ^ can delete the multiple borders that follow the BG's for now.
    [Header("Infinite clouds background")]
    [SerializeField] GameObject[] Clouds;


    [SerializeField]
    Transform CenterBackground;

    void Start()
    {   // Starting position of Camera.
        transform.position = new Vector3(0, 1, -10f);
    }

    void Update()
    {   // Camera follows Target.
        if (Target.position.y >= 1.7f)
            // starts following after 1.7f. but will drop back down if player "falls".
            // need to implement death



        { transform.position = new Vector3(transform.position.x, Target.position.y, transform.position.z); }
        // Background switches when above a certain height
        if (transform.position.y >= CenterBackground.position.y + 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y + 23f, 1); }
        // Background switches below a certain height
        else if (transform.position.y <= CenterBackground.position.y - 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y - 23f, 1); }
    }
}

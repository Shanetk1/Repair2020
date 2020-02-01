using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform CenterBackground;
    public GameObject Player01;
    public GameObject Player02;
    float DistanceBetweenPlayers;
    bool StartCheckPoint;
    GameObject Target;
    /** Camera has 2 anchors.
        * MidAnchor - Shows middle of sreen by calculating DistanceBetweenPlayers.
        *           - Anchor for Borders and CloudSpawnPoints.
        * BotAnchor - OnTriggerExit (for death) collider with lowest point Player can fall.
     ***/
    [Header("Infinite clouds background")]
    [SerializeField] GameObject[] Clouds;
    // Still need to spawn clouds. Destroy clouds upon OnTriggerExit

    void Start()
    {   // CheckPoint is only used once. Eliminates (most) of camera jumpiness at start of game,
        StartCheckPoint = false; // when transitioning between static and then following player.
        transform.position = new Vector3(0, 1, -10f);   // Starting position of Camera.
    }

    void Update()
    {   // Camera follows Target.
        LowestPlayer();
        if (Target.transform.position.y >= 1.7 || StartCheckPoint == true || DistanceBetweenPlayers >= 17)
        { transform.position = new Vector3(transform.position.x, Target.transform.position.y+DistanceBetweenPlayers/2, transform.position.z); }
        // Background switches when above a certain height, uses CenterBackground as anchor.
        if (transform.position.y >= CenterBackground.position.y + 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y + 23f, 1); }
        // Background switches below a certain height, uses CenterBackground as anchor.
        else if (transform.position.y <= CenterBackground.position.y - 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y - 23f, 1); }
    }

    // Camera checks which Player is nearest bottom of screen, and switches between
    void LowestPlayer() // Player01 or Player02.
    {
        if (Player01.transform.position.y <= Player02.transform.position.y)
        {
            DistanceBetweenPlayers = Player02.transform.position.y - Player01.transform.position.y;
            Target = Player01;
        }
        else if (Player02.transform.position.y <= Player01.transform.position.y)
        {
            DistanceBetweenPlayers = Player01.transform.position.y - Player02.transform.position.y;
            Target = Player02;
        }
        if (DistanceBetweenPlayers >= 17) { StartCheckPoint = true; }
    }
}

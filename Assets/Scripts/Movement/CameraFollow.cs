using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    CloudDrift CloudDrift;
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
    [SerializeField] GameObject[] CloudsSpawnPoint;

    void Start()
    {   // CheckPoint is only used once. Eliminates (most) of camera jumpiness at start of game,
        StartCheckPoint = false; // when transitioning between static and then following player.
        transform.position = new Vector3(0, 1, -10f);   // Starting position of Camera.
        Invoke("StartClouds", 10);
    }

    void Update()
    {   // Remove Null Reference Error when destroyed Player GameObject.
        try
        {
            LowestPlayer();
            CameraFollowing();
            BackgroundChanging();
        }
        catch { }
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

    void CameraFollowing()
    {
        if (Target.transform.position.y >= 1.7 || StartCheckPoint == true || DistanceBetweenPlayers >= 17)
        { transform.position = new Vector3(transform.position.x, Target.transform.position.y + DistanceBetweenPlayers / 2, transform.position.z); }

        // Tracking Main Camera distance
        if ((int)transform.position.y >= 50)
        {   // Camera will detach and speed.
                    
                    // STILL NEED TO DO
        }
    }

    void BackgroundChanging()
    {   // Background switches when above a certain height, uses CenterBackground as anchor.
        if (transform.position.y >= CenterBackground.position.y + 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y + 23f, 10); }
        // Background switches below a certain height, uses CenterBackground as anchor.
        else if (transform.position.y <= CenterBackground.position.y - 23f)
        { CenterBackground.position = new Vector3(CenterBackground.position.x, transform.position.y - 23f, 10); }
    }

    void StartClouds() { StartCoroutine(CloudsSpawning()); }
    IEnumerator CloudsSpawning()
    {   // Takes the MidAnchor and spawns randomly.
        float RandomHeight = Random.Range((Target.transform.position.y - 7), (Target.transform.position.y + 7));
        Instantiate(Clouds[Random.Range(0, 2)], /* x is chosen between 2 random spawn points*/
            new Vector3(CloudsSpawnPoint[Random.Range(0, 2)].transform.position.x, RandomHeight, 9), Quaternion.identity);
        yield return new WaitForSeconds(6);
        StartCoroutine(CloudsSpawning());
    }
}

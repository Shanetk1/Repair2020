﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGeneration : MonoBehaviour
{
    //NEED TO ADD DELETION METHOD //COULD BE TIME BASED WHICH IS THE CHEAP WAY OF DOING IT 

    private const float DIST_FROM_CAMERA = 15f; //This is because the camera controls the game flow NOT THE PLAYER ///Basically, if camera is 20f away from mapend create new map

    [SerializeField] private Transform mapPiece;
    [SerializeField] private List<Transform> mapPieces;



    private Vector3 endPosition;
    public Camera myCam;

    private Transform oldestMap;
    private void Awake()
    {
        Transform mapTransform;
        mapTransform = spawnPiece(mapPiece ,new Vector3(0.0f, 0.0f)); //Spawning our spawnMap PIECE AT ORIGIN
        oldestMap = mapTransform;
        //^ Above must be done ON AWAKE because it is our origin map piece



        endPosition = mapPiece.Find("EndPos").position;


    



    }

    void Start()
    {
       // myCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distCam = myCam.transform.position.y;
        float lastMapEnd = endPosition.y;
        //^ This is because camera is locked on all other axis **THIS IS BAD IF CAMERA WASN'T LOCKED THIS BREAKS**
       
        if (lastMapEnd - distCam < DIST_FROM_CAMERA)
        {
          //  deletePiece()
            spawnPiece();
        }


        
    }
    private void spawnPiece()
    {
        Transform chosenPart = mapPieces[Random.Range(0, mapPieces.Count)];
        Transform mapEndPosition = spawnPiece(chosenPart, endPosition);         //BASICALLY, hey spawn the piece using old endPos, then return the new map piece TRANSFORM to the variable
        endPosition = mapEndPosition.Find("EndPos").position;       //NOW RE-ASSIGN endPosition to find the most RECENTLY created MAP PIECE "EndPos"
    }
    private Transform spawnPiece(Transform levelPart, Vector3 Pos)
    {
        Transform myTransform = Instantiate(levelPart, Pos, Quaternion.identity);

        return myTransform;
    }

    private void deletePiece()
    {
        Destroy(oldestMap.gameObject, 5);
    }
}


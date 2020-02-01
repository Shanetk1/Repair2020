using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Platform", menuName = "Game_Objects/Platforms")]
public class Platform : ScriptableObject
{
    public bool isPlayer1;//Checks if collision is enabled or disabled for player1
}

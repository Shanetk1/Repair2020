using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {

    public enum Game { h_0, h_500, h_1000, h_1500, Dead, GameOver }
    public Game State;
    public Text TextDistance;
    public Text TextScore;
    public Text TextTime;
          float Timer;

    public GameObject MCamera;
    public int Distance;
    public int Score;

    void Start()
    {
        State = Game.h_0;
    }

    void Update()
    {   // Updating time when still playing.
        if (State != Game.Dead)
        {   // Calculating distance jumped.
            Distance = (int) MCamera.transform.position.y;
            UIUpdate();
        }
    }

    // Updating Time, Distance, and Score.
    void UIUpdate()
    {
        Timer += Time.deltaTime;
        float minutes = Timer / 60;
        float seconds = Timer % 60;

        TextDistance.text = "Distance: " + Distance + "m";
        TextScore.text = "\n     Score: " + Score;
        TextTime.text = string.Format("Time: {0:00} : {1:00}", minutes, seconds);
    }
}

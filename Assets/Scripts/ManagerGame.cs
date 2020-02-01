using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {

    public Text TextDistance;
    public Text TextScore;
    public Text TextTime;
          float Timer;

    public int Distance;

    void Start()
    {

    }

    void Update()
    {
        UIUpdate();
    }
    
    // Updating Time, Distance, and Score.
    void UIUpdate()
    {
        Timer += Time.deltaTime;
        float minutes = Timer / 60;
        float seconds = Timer % 60;

        TextDistance.text = "Distance: " + Distance;
        TextScore.text = "\n     Score: " + "smh";
        TextTime.text = string.Format("Time: {0:00} : {1:00}", minutes, seconds);
    }
}

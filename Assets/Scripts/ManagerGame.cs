using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {

    public Text Height;
    public Text Score;
    public Text ShowTime;
    float Timer;

    void Start()
    {

    }

    void Update()
    {
        Timer += Time.deltaTime;
        float minutes = Timer / 60;
        float seconds = Timer % 60;

        Height.text = "Height: " + "smh";
        Score.text = "\n Score: " + "smh";
        ShowTime.text = string.Format("Time: {0:00} : {1:00}", minutes, seconds);
    }
}

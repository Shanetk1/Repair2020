using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource jump;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            jump.Play();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            jump.Play();

    }


}

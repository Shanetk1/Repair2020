using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeDelay = 5.0f;
    public Animator myAnim;

    private float timePast;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePast += Time.deltaTime;
        

        if (timeDelay < timePast)
        {
            //Play Animation
            myAnim.SetTrigger("doSomething");
            timePast = 0.0f;

        }
        
    }
}

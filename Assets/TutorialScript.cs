using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] myImages;
    public GameObject myButton;

    public void Close()
    {
        Time.timeScale = 1.0f;
    }
    public void Next()
    {
        if (myImages[0].activeSelf == true)
        {
            myImages[0].SetActive(false);
            myImages[1].SetActive(true);
        }
        else if (myImages[1].activeSelf == true)
        {
            myImages[1].SetActive(false);
            myImages[2].SetActive(true);
        }
        else if (myImages[2].activeSelf == true)
        {
            myImages[2].SetActive(false);
            myImages[3].SetActive(true);
        }
        else if (myImages[3].activeSelf == true)
        {
            myImages[3].SetActive(false);
            myImages[4].SetActive(true);
        }
        else if (myImages[4].activeSelf == true)
        {
            myImages[4].SetActive(false);
            myButton.SetActive(false);
        }




    }

}

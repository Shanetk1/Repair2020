using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector2.left);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector2.left);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up);
		}
	}
}

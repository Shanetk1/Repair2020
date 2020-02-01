using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrift : MonoBehaviour {

    float Speed;
    int CloudDirection;

    void Start()
    {
        Speed = Random.Range(3, 7);
        CloudDirection = Random.Range(0, 2) * 2 - 1;   // Only Left(1) or Right(-1).
    }

    void Update()
    {
        transform.Translate(Vector3.left * CloudDirection * Speed * Time.deltaTime);
        if (gameObject.transform.position.x <= -30) { Destroy(this.gameObject); }
        if (gameObject.transform.position.x >=  30) { Destroy(this.gameObject); }
    }
}
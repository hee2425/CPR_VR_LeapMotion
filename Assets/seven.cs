using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seven : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = 0.232f;
            vector.y = -0.16405f;
            vector.z = 0.494f;

            transform.position = vector;

        }
    }
}

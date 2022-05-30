using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class four : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = -0.082f;
            vector.y = -0.325f;
            vector.z = 0.595f;

            transform.position = vector;

        }
    }
}

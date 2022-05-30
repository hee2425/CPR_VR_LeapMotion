using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class six : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = 1183.7f;
            vector.y = -698.48f;
            vector.z = -2004.6f;

            transform.position = vector;

        }
    }
}

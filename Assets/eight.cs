using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eight : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = 0.311f;
            vector.y = -0.14104f;
            vector.z = 0.404f;

            transform.position = vector;

        }
    }
}

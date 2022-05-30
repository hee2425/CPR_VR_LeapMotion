using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nine : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = 1197.6f;
            vector.y = -698.5f;
            vector.z = -2032.7f;

            transform.position = vector;

        }
    }
}

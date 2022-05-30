using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class two : MonoBehaviour {
    public Vector3 vector;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speaker.flag == 10)
        {

            vector = transform.position;
            vector.x = -0.312f;
            vector.y = -0.149f;
            vector.z = 0.608f;

            transform.position = vector;

        }
    }
}

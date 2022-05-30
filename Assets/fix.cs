using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "fix")
        {
            print("fix");
            Cam_Move_Ctr.contact = true;

        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {
    public Text stime;
    public int min =0;
    public int sec = 0;
    public int newtime = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        newtime = (int)ardunityupdown.rtime / 1000;
       min = newtime / 60;
        sec = newtime % 60;
        stime.text = ardunityupdown.rtime.ToString();
    }
}

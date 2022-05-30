using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour {

    public Text sspeed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sspeed.text = ardunityupdown.notspeed.ToString();

    }
}

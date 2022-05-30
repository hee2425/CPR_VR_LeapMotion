using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressure : MonoBehaviour
{

    public Text spressure;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spressure.text = ardunityupdown.notpressure.ToString();

    }
}

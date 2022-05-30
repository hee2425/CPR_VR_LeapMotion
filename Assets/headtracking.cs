using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class headtracking : MonoBehaviour {
    private Gyroscope gyro;
    // Use this for initialization
    void Start () {
        if (SystemInfo.supportsGyroscope) { gyro = Input.gyro; gyro.enabled = true; } else { Debug.Log("Phone doesen't support"); }
    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, -Input.gyro.rotationRateUnbiased.z);
    }

    void OnGUI() { GUILayout.Label("Gyroscope attitude : " + gyro.attitude); }
}



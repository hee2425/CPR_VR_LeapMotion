using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour {

    // Use this for initialization
    public Button m_YourButton;
	void Start () {
        Button btn = m_YourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
       // m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });

    }

    void TaskOnClick()
    {
        this.transform.Translate(Vector3.forward * 20.0f * Time.deltaTime);
    }
    // Update is called once per frame

    void TaskWithParameters(string message)
    {
        Debug.Log(message);
    }
    void Update () {
		
	}
}

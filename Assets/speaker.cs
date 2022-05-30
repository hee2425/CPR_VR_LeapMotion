using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using UnityEngine.Audio;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class speaker : MonoBehaviour {

    public static int flag;
    public GameObject human;
    public GameObject hand;
    public GameObject slider;
    public GameObject text;
    public GameObject buttonclose;

    public AudioClip[] clips;
    public AudioClip[] clips2;
    public AudioClip[] clips3;
    public AudioMixerGroup output;
    public Stopwatch sw = new Stopwatch();
    // Use this for initialization
    void Start () {

        human.SetActive(false);
        hand.SetActive(false);
        slider.SetActive(false);
        text.SetActive(false);
        buttonclose.SetActive(false);

        flag = 0;
        if (flag == 0)
        {
            PlayZero();
           
        }
        //;
    }

    void PlayZero()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips[0];
        //number.outputAudioMixerGroup = output;
        number.Play();

        Invoke("PlayFirst", 5);
        

    }
    void PlayFirst()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips2[0];
        //number.outputAudioMixerGroup = output;
        number.Play();
        flag = 10;
        human.SetActive(true);
        buttonclose.SetActive(true);
        hand.SetActive(true);
        slider.SetActive(true);
    }

    void PlaySecnod()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips3[0];
        //number.outputAudioMixerGroup = output;
        number.Play();
     //   flag = 10;
  
    }



    // Update is called once per frame
    void Update () {

        if (flag == 1)
        {
           

            PlayFirst();
          
        }

        if (Cam_Move_Ctr.contact == true)
        {
            Invoke("PlaySecond", 5);
        }


    }

    
}

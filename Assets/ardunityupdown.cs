using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using UnityEngine.Audio;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class ardunityupdown : MonoBehaviour {

    public float speed;
    public GameObject scorepan;
   
    int i = 0;
    public int count = 0;
    public Slider Slider;
    public Text text;
    public AudioClip[] clips;
    public AudioMixerGroup output;
    public AudioClip[] clips2;
    public AudioMixerGroup output2;
    public AudioClip[] clips3;
    public AudioMixerGroup output3;
    public AudioClip[] clips4;
    public AudioMixerGroup output4;
    public AudioClip[] clips5;
    public AudioMixerGroup output5;
    public bool playOnAwake =false;
    public Stopwatch sw = new Stopwatch();
    public Stopwatch time = new Stopwatch();

    public static long rtime;
    public static int pro=0;
    public static int notpressure=0;
    public static int notspeed=0;


    private float amoutToMove;
    SerialPort sp = new SerialPort("COM4", 9600);
    // Use this for initialization
    void Start()
    {
        scorepan.SetActive(false);
        text.gameObject.SetActive(false);
        playOnAwake = false;
        sp.Open();
        sp.ReadTimeout = 1;
        time.Start();

    }

 
    // Update is called once per frame
    void Update()
    {
        amoutToMove = speed * Time.deltaTime;
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                print(sp.ReadByte());
            }

            catch (System.Exception)
            {
                //throw;
            }
        }
    }

    void PlaySound()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips[count];
        number.outputAudioMixerGroup = output;
        number.Play();
    }

    void PlayWeak()
    {
        notpressure++;
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips2[count];
        number.outputAudioMixerGroup = output2;
        number.Play();
    }

    void Siren()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips4[count];
        number.outputAudioMixerGroup = output4;
        number.Play();
    }

    void Complete()
    {
       
        Slider.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
       

    }

     void PlaySpeed()
    {
        notspeed++;
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips3[count];
        number.outputAudioMixerGroup = output3;
        number.Play();
    }

    void Repeat()
    {
        AudioSource number = gameObject.AddComponent<AudioSource>();
        number.clip = clips5[count];
        number.outputAudioMixerGroup = output5;
        number.Play();
    }

    void score()
    {
        scorepan.SetActive(true);
    }

    void MoveObject(int Direction)
    { 
        if (Direction == 1 && i<0)
        {
            transform.Translate(Vector3.up * 0.05f, Space.World);
            i++;
            sw.Start();

        }

        if (Direction == 3 && i > -1)
        {
            // Invoke("PlayWeak", 0.5f);
            PlayWeak();
            
        }

        if (Direction == 2 && i>-1)
        {
            transform.Translate(Vector3.down * 0.05f, Space.World);
            i--;

            
            sw.Stop();
            print("sw"+count +":" + sw.ElapsedMilliseconds.ToString() + "ms");
            if (sw.ElapsedMilliseconds > 1000)
            {
                print("error");

                Invoke("PlaySpeed", 0.3f);
               // PlaySpeed();

            }


            PlaySound();

            count++;
            Slider.value = count;
            if (Slider.value == 30)
            {
                Repeat();
            }
            if (Slider.value == 60)
            {
                pro = 60 + notspeed + notpressure;
                time.Stop();
                rtime = time.ElapsedMilliseconds;
                Complete();
                Siren();

                Invoke("score", 10);

            }
            sw.Reset();



        }

       
    }
}


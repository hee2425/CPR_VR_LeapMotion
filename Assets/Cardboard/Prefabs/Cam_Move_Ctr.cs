using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using UnityEngine.Audio;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class Cam_Move_Ctr : MonoBehaviour
{
    public GameObject cube;
    public GameObject fix;
    public static bool contact = false;
    public Vector3 vector;
    Controller controller;
    float HandPalmpitch;
    float HandPalmYaw;
    float HandPalmRoll;
    float HandWristRot;


    float HandPalmpitch2;
    float HandPalmYaw2;
    float HandPalmRoll2;
    float HandWristRot2;


    float lifetimeOfThisHandObject;
    float lifetimeOfThisHandObject2;

    float a, b, c; //왼손 좌표
    float a2, b2, c2; //오른손 좌표
    float a3, b3, c3; //오른손 - 왼손 좌표

    int i = 1;
    public static int j = 0;

    LeapProvider provider;



    // Use this for initialization
    void Start()
    {
        contact = false;
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

    }




    // Update is called once per frame
    void Update()
    {
        
        if (speaker.flag == 10)
        {
            if (contact == false)
            {


                try
                {
                    MOVE();
                }

                catch (System.Exception)
                {
                    //throw;
                    
                }

            }
      }

    }

    void MOVE()
    {
    
        controller = new Controller();
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        HandPalmpitch = hands[0].PalmNormal.Pitch;
        HandPalmRoll = hands[0].PalmNormal.Roll;
        HandPalmYaw = hands[0].PalmNormal.Yaw;
        HandWristRot = hands[0].WristPosition.Pitch;


        HandPalmpitch2 = hands[1].PalmNormal.Pitch;
        HandPalmRoll2 = hands[1].PalmNormal.Roll;
        HandPalmYaw2 = hands[1].PalmNormal.Yaw;
        HandWristRot2 = hands[1].WristPosition.Pitch;


        float lifetimeOfThisHandObject = hands[0].TimeVisible;
        float lifetimeOfThisHandObject2 = hands[1].TimeVisible;

        Vector handCenter = hands[0].PalmPosition;
        Vector handCenter2 = hands[1].PalmPosition;

        //Left_Value = handCenter;
        //Right_Value = handCenter2;

        a = handCenter.x;
        b = handCenter.y;
        c = handCenter.z;

        a2 = handCenter2.x;
        b2 = handCenter2.y;
        c2 = handCenter2.z;

        Vector RightHand_LeftHand = handCenter2 - handCenter;

        //Debug.Log("Pitch :" + HandPalmpitch);
        //Debug.Log("Roll :" + HandPalmRoll);
        //Debug.Log("Yaw :" + HandPalmYaw);



        Frame frame2 = provider.CurrentFrame;
        foreach (Hand hand in frame2.Hands)
        {
            /*
            if (hand.IsLeft || hand.IsRight)
            {

                Debug.Log("Left_Pitch :" + HandPalmpitch);
                Debug.Log("Left_Roll :" + HandPalmRoll);
                Debug.Log("Left_Yaw :" + HandPalmYaw);

                Debug.Log("Right_Pitch :" + HandPalmpitch2);
                Debug.Log("Right_Roll :" + HandPalmRoll2);
                Debug.Log("Right_Yaw :" + HandPalmYaw2);



                //Debug.Log("Left hand is present");
                //transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));
                //this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f); //좌회전
            }
            */


            /*
            
            if (hand.IsLeft
                && (HandPalmpitch < -1.45f && HandPalmpitch > -1.8f)

                && (HandPalmpitch2 > -1.8f && HandPalmpitch2 < -1.4f)

                && (HandPalmRoll > 0.08f && HandPalmRoll < 0.15f)

                && (HandPalmRoll2 > -0.1f && HandPalmRoll2 < 0.17f)

                && (HandPalmYaw < 2.5f && HandPalmYaw > 0.8f))

            {

                Debug.Log("두 손이 겹쳤어요!" + i);

            
                
                Debug.Log("Left_Pitch :" + HandPalmpitch);
                Debug.Log("Left_Roll :" + HandPalmRoll);
                Debug.Log("Left_Yaw :" + HandPalmYaw);

                Debug.Log("Right_Pitch :" + HandPalmpitch2);
                Debug.Log("Right_Roll :" + HandPalmRoll2);
                Debug.Log("Right_Yaw :" + HandPalmYaw2);
                
                i++;

            }
            */


            /*
            if (hand.IsLeft && HandPalmYaw < -2.2f)
            {
                //transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime));
            }

            if (hand.IsRight && HandPalmYaw < -2.0f)
            {
                //Debug.Log("Right hand is present");
                //transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime));
            }

            if (hand.IsRight && HandPalmYaw > -0.3f)
            {
                //Debug.Log("Right hand is present");
                //transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));
            }


            if (hand.IsLeft)
            {
                //Debug.Log("left hand are present");
                //Debug.Log("left time :" + lifetimeOfThisHandObject);
                //Debug.Log("Left Vector :" + handCenter);
                //Debug.Log("Left Value component :" + a + "," + b + "," + c);

            }
            */

            if (hand.IsRight)
            {
                //Debug.Log("right hand are present");
                //Debug.Log("right time :" + lifetimeOfThisHandObject2);
                //Debug.Log("Right Vector :" + handCenter2);
                //Debug.Log("Right Value component :" + a2 + "," + b2 + "," + c2);
                //Debug.Log("Right Value - Left Value :" + RightHand_LeftHand);

            }

            a3 = a2 - a;
            b3 = b2 - b;
            c3 = c2 - c;

            if (a2 - a <= 0)
            {
                a3 = -(a2 - a);
            }

            if (b2 - b <= 0)
            {
                b3 = -(b2 - b);
            }

            if (c2 - c <= 0)
            {
                c3 = -(c2 - c);
            }


            if ((a3 < 50) && (b3 < 10) && (c3 < 5))
            {
                Debug.Log("두 손이 겹쳤어요!" + i);
                Debug.Log("Right Value - Left Value :" + RightHand_LeftHand);
                //cube.SetActive(false);
                i++;
                j = 1;
            }

            /*
            if(j==1)
            {
                a2 = a + 50;
                b2 = b + 40;
                c2 = c + 30;
            }
            */

            if (hand.IsLeft && HandPalmRoll < -2.0f && HandPalmRoll > -2.7f && HandPalmpitch < 2.5f && HandPalmpitch > 0.5f)
            {
                //정지(왼손 좌측방향)
                transform.Translate(new Vector3(0, 0, 0 * Time.deltaTime));
            }

            if (hand.IsLeft && HandPalmRoll < -0.25f && HandPalmRoll > -1.2f && HandPalmpitch < -1.0f && HandPalmpitch > -2.5f)
            {
                //직전(왼손 우측방향)
                transform.Translate(new Vector3(0, 0, 0.4f * Time.deltaTime));
            }


            if (hand.IsRight && HandPalmRoll2 < 1.1f && HandPalmRoll2 > 0.18f && HandPalmpitch2 < -1.0f && HandPalmpitch2 > -2.0f)
            {
                //좌회전(오른손 좌측방향)
                this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
            }

            if (hand.IsRight && HandPalmRoll2 < 2.85f && HandPalmRoll2 > 1.8f && HandPalmpitch2 < 2.5f && HandPalmpitch2 > 0.5f)
            {
                //우회전(오른속 우측방향)
                this.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
            }


        }

        if (frame.Hands.Count > 0)
        {
            Hand firstHand = hands[0];
            Hand secondHand = hands[1];
        }

    }
}
   
        





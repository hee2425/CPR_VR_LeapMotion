using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewithwaypoints : MonoBehaviour {

    public enum State
    {
        Idle, Move, Attack, Dead
    }
    public Vector3 vector;
    public State state = State.Idle;

    public float moveSpeed = 30f;
    public float rotSpeed = 540f;

    // 애니메이터 컴포넌트.
   // public Animator refAnimator;

    public Transform waypointRoot;

    private Transform[] waypoints;
    private Transform targetPoint;

    Transform refTransform;
    Vector3 targetPos;

    private float elapsedTime = 0f;
    private float waitTime = 2f;

    void Awake()
    {
      //  refAnimator = GetComponent<Animator>();
        refTransform = GetComponent<Transform>();

        waypoints = waypointRoot.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        FSM();

        if (speaker.flag == 10)
        {
             moveSpeed = 0f;
            rotSpeed = 0f;
           
        }
    }

    void FSM()
    {
        switch (state)
        {
            case State.Idle: Idle(); break;
            case State.Move: Move(); break;
            default: break;
        }
    }

    void Idle()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > waitTime)
        {
            elapsedTime = 0f;
            targetPos = waypoints[Random.Range(0, waypoints.Length)].position;

            state = State.Move;
            //refAnimator.SetInteger("state", (int)state);
        }
    }

    void Move()
    {
        float remainDistance = MoveByFrame();
        RotateByFrame();
        if (remainDistance == 0f)
        {
            state = State.Idle;
           // refAnimator.SetInteger("state", (int)state);
        }
    }

    float MoveByFrame()
    {
        // 캐릭터 위치에서 목표 위치까지의 벡터 구하기.
        Vector3 targetDir = targetPos - refTransform.position;
        targetDir.y = 0f;

        // 이동속도 * 프레임시간을 적용해서 프레임마다 이동.
        // targetDir.normalized는 단위벡터.
        Vector3 framePos = moveSpeed * Time.deltaTime * targetDir.normalized;
        float remainDistance = GetMagnitude(targetDir);
        refTransform.position =
            remainDistance > GetMagnitude(framePos) ?
            refTransform.position + framePos : targetPos;

        return GetMagnitude(targetDir);
    }

    void RotateByFrame()
    {
        Vector3 targetDir = targetPos - refTransform.position;
        targetDir.y = 0f;
        if (targetDir == Vector3.zero) return;

        float targetAngle = GetAngle(refTransform.forward, targetDir);
        if (float.IsNaN(targetAngle)) return;

        float frameAngle =
                targetAngle > 0f ?
                rotSpeed * Time.deltaTime :
                -rotSpeed * Time.deltaTime;

        bool remainCheck = Mathf.Abs(targetAngle) > Mathf.Abs(frameAngle);
        Vector3 frameRot = new Vector3(0f, frameAngle, 0f);

        //refTransform.rotation *= Quaternion.Euler(frameRot);
        refTransform.rotation *=
            remainCheck ?
            Quaternion.Euler(frameRot) :
            Quaternion.Euler(new Vector3(0f, targetAngle, 0f));
    }

    float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    float GetMagnitude(Vector3 a)
    {
        return Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
    }

    float Rad2Deg
    {
        get { return 57.29579143313326f; }
    }

    float GetAngle(Vector3 from, Vector3 to)
    {
        float dot = Dot(from, to);
        float magnitude = GetMagnitude(from) * GetMagnitude(to);
        float angle = Mathf.Acos(dot / magnitude);
        angle = -(from.x * to.z - to.x * from.z) > 0f ? angle : -angle;

        return angle * Rad2Deg;
    }
}

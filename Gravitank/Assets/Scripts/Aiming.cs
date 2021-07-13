using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;
public class Aiming : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject Head;
    public KeyCode ClockwiseKey;
    public KeyCode CounterClockwiseKey;
    float currentAngle = 0;

    void Update()
    {
        if (Input.GetKey(ClockwiseKey)) Clockwise();
        if (Input.GetKey(CounterClockwiseKey)) CounterClockwise();
    }
    void Clockwise()
    {   //angle limit
        if (currentAngle > -BARREL_MAX_ANGLE)
        {   // barrel rotates around head
            Barrel.transform.RotateAround(Head.transform.position, Vector3.forward, -BARREL_ANGLE_DELTA);
            currentAngle -= BARREL_ANGLE_DELTA;
        }
    }
    void CounterClockwise()
    {
        //angle limit
        if (currentAngle < BARREL_MAX_ANGLE)
        {   //barrel rotates around head
            Barrel.transform.RotateAround(Head.transform.position, Vector3.forward, BARREL_ANGLE_DELTA);
            currentAngle += BARREL_ANGLE_DELTA;
        }
    }
}

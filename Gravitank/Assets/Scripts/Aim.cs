using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject Barrel;
    public KeyCode ClockwiseKey;
    public KeyCode CounterClockwiseKey;
    private float currentAngle = 0;
    //HACK
    const float maxAngle = 90;
    const float angleDelta = 0.05f;

    void Update()
    {
        if (Input.GetKey(ClockwiseKey)) Clockwise();
        if (Input.GetKey(CounterClockwiseKey)) CounterClockwise();
    }
    void Clockwise()
    {
        if (currentAngle > -90)
        {
            Barrel.transform.RotateAround(transform.position, Vector3.forward, -angleDelta);
            currentAngle -= angleDelta;
        }
    }
    void CounterClockwise()
    {
        if (currentAngle < 90)
        {
            Barrel.transform.RotateAround(transform.position, Vector3.forward, angleDelta);
            currentAngle += angleDelta;
        }

    }
}

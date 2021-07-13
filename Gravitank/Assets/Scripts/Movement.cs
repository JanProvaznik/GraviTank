using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;
public class Movement : MonoBehaviour
{
    public KeyCode Clockwise;
    public KeyCode CounterClockwise;
    void Update()
    {
        // don't allow movement if going too fast
        if (GetComponent<Rigidbody2D>().velocity.magnitude < MOVEMENT_MAX_VELOCITY_MAGNITUDE)
        {
            if (Input.GetKey(Clockwise)) Move(true);
            if (Input.GetKey(CounterClockwise)) Move(false);
        }
    }
    void Move(bool clockwise)
    {   // ternary for negating direction, transform.right is a unit vector
        Vector2 direction = (clockwise ? 1 : -1) * transform.right;
        GetComponent<Rigidbody2D>().AddForce(direction * MOVEMENT_FORCE_MAGNITUDE);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private const float movementMagnitude = 0.1f;
    private const float maxVelocityMagnitude = 0.5f;
    public KeyCode Left;
    public KeyCode Right;

    void Update()
    {
        // don't allow change of movement if going too fast
        if (GetComponent<Rigidbody2D>().velocity.magnitude < maxVelocityMagnitude)
        {
            if (Input.GetKey(Left))
            {
                Vector2 direction = -transform.right;
                GetComponent<Rigidbody2D>().AddForce(direction * movementMagnitude);
                // Debug.Log(a);
            }
            if (Input.GetKey(Right))
            {
                Vector2 direction = transform.right;
                GetComponent<Rigidbody2D>().AddForce(direction * movementMagnitude);

            }
        }

    }
}

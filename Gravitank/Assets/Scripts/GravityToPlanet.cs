using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToPlanet : MonoBehaviour
{
    public GameObject planet;
    const float gravityConstant = 30;
   
    // update for physics
    void FixedUpdate()
    {
        Vector2 direction = (planet.GetComponent<Transform>().position - transform.position);
        float distance = direction.magnitude;
        GetComponent<Rigidbody2D>().AddForce(gravityConstant* direction.normalized /(distance*distance));
        
    }
}

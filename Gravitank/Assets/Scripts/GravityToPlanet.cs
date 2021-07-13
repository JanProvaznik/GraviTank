using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;
public class GravityToPlanet : MonoBehaviour
{
    public GameObject planet;

    // update for physics
    void FixedUpdate()
    {
        Vector2 direction = (planet.transform.position - transform.position);
        float distance = direction.magnitude;
        GetComponent<Rigidbody2D>().AddForce(PLANET_GRAVITY * direction.normalized / Mathf.Pow(distance, GRAVITY_EXPONENT));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;

public class Meteor : MonoBehaviour
{
    void Start()
    {   // meteors spawn headed a random way
        Vector2 force = new Vector2(Random.Range(0, METEOR_MAX_FORCE), Random.Range(0, METEOR_MAX_FORCE));
        GetComponent<Rigidbody2D>().AddForce(force);
    }
    void Update()
    {
        Slowdown();
    }
    // limit the velocity so that players can dodge
    void Slowdown()
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        if (velocity.magnitude > METEOR_MAX_VELOCITY_MAGNITUDE)
            GetComponent<Rigidbody2D>().velocity = METEOR_MAX_VELOCITY_MAGNITUDE * velocity.normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // damage player
        if (other.tag == "Damageable")
            other.GetComponent<Health>().TakeDamage(METEOR_DAMAGE);
        // meteor is not destroyed by shots
        if (other.tag != "Shot")
            Destroy(this.gameObject);
    }
}

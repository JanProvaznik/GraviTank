using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ShotDamage : MonoBehaviour
{
    float creationTime;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = SHOT_BASE_DAMAGE;
        creationTime = Time.time;

    }

    // Update is called once per frame
    void CountInitialPower(float initialPower)
    {
        damage = damage * initialPower * SHOT_DAMAGE_POWER_COEFFICIENT;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damageable")
        {
            InAirDamage();
            Debug.Log(damage);
            other.GetComponent<Health>().TakeDamage(damage);
        }
        //TODO: animace?
        Destroy(this.gameObject);
    }
    void InAirDamage()
    {
        float timeInAir = Time.time - creationTime;
        damage *= timeInAir * SHOT_DAMAGE_TIME_COEFFICIENT;
    }

}

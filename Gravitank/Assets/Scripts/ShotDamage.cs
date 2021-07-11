using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDamage : MonoBehaviour
{
    const float initialDamage = 1;
    const float flyCoefficient = 1.5f;
    const float powerCoefficient = 1;
    float creationTime;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = initialDamage;
        creationTime = Time.time;

    }

    // Update is called once per frame
    void CountInitialPower(float initialPower)
    {
        damage = damage * initialPower * powerCoefficient;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("collision");
        if (other.tag == "Damageable")
        {
            InAirDamage();
            other.GetComponent<Health>().TakeDamage(damage);
        }
        //TODO: animace?
        Destroy(this.gameObject);
    }
    void InAirDamage()
    {
        float timeInAir = Time.time - creationTime;
        damage *= timeInAir*flyCoefficient;
    }

}

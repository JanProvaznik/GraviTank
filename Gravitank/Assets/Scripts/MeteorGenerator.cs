using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class MeteorGenerator : MonoBehaviour
{
    public GameObject Meteor;
    void Start()
    {
        
    }

    void Update()
    {
        float frequency = BASE_METEOR_FREQUENCY + Time.time * TIME_METEOR_FREQUENCY_COEFFICIENT;
        if (Random.Range(0f,1f) < frequency) MakeMeteor();
    }

    void MakeMeteor(){
        Vector2 pos = new Vector2();
        Vector2 force = new Vector2();
        Instantiate(Meteor,pos,Quaternion.identity);
        Meteor.GetComponent<Rigidbody2D>().AddForce(force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;

public class MeteorGenerator : MonoBehaviour
{
    public GameObject Meteor;
    void Update()
    {   // frequency depends on game time
        float frequency = BASE_METEOR_FREQUENCY + Time.timeSinceLevelLoad * TIME_METEOR_FREQUENCY_COEFFICIENT;
        if (Random.Range(0f, 1f) < frequency) MakeMeteor();
    }

    void MakeMeteor()
    {   // random angle
        float angle = Random.Range(0, 2 * 3.14f);
        // random distance
        float distance = Random.Range(METEOR_MIN_DISTANCE, METEOR_MAX_DISTANCE);
        // combine to get position
        Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
        Instantiate(Meteor, pos, Quaternion.identity);
    }
}

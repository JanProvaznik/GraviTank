using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Shot;

    public GameObject FirePoint;
    public KeyCode ShootKey;
    //HACK
    // in seconds
    const float cooldown = 4;
    float lastShotTime=0;
    float shotPower= 4f; 
    const float minShotPower=3f;
    const float maxShotPower=5f;
    enum ShootingState{cooldown, aiming, idle};
    void Update()
    {
        if (Input.GetKeyDown(ShootKey) &&lastShotTime>=cooldown){
            Shoot(); lastShotTime=0;}
        lastShotTime += Time.deltaTime;
        // Debug.Log(lastShotTime);
    }
    void Shoot()
    {
        //TODO: add shotpower loading
        GameObject newShot = Instantiate(Shot, FirePoint.transform.position, FirePoint.transform.rotation);
        RandomShotPower();
        newShot.GetComponent<Rigidbody2D>().velocity = + shotPower*((Vector2)FirePoint.transform.position - (Vector2)transform.position).normalized;

    }
    void RandomShotPower(){
        shotPower=  Random.Range(minShotPower,maxShotPower);
    }
}

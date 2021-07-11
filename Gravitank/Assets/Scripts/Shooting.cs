using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class Shooting : MonoBehaviour
{
    public GameObject Shot;
    public GameObject Barrel;

    public GameObject FirePoint;
    public KeyCode ShootKey;
    public GameObject PowerSlider;
    //HACK
    // in seconds
    float timeSinceLastShot = 0;
    float shotPower = 4f;
    bool powerIncreasing = true;
    enum ShootingState { cooldown, loading, idle };
    ShootingState state = ShootingState.cooldown;
    void Update()
    {
        switch (state)
        {
            case ShootingState.cooldown:
                timeSinceLastShot += Time.deltaTime;
                if (timeSinceLastShot >= SHOT_COOLDOWN)
                    state = ShootingState.idle;
                break;
            case ShootingState.loading:
                if (Input.GetKeyUp(ShootKey))
                {
                    state = ShootingState.cooldown;
                    Shoot();
                }
                else { PowerChange(); }
                break;
            case ShootingState.idle:
                if (Input.GetKeyDown(ShootKey))
                {
                    state = ShootingState.loading;
                    RandomShotPower();
                }
                break;
        }
        UpdateDisplay();
        // Debug.Log(lastShotTime);
    }
    void Shoot()
    {
        GameObject newShot = Instantiate(Shot, FirePoint.transform.position, FirePoint.transform.rotation);
        newShot.GetComponent<Rigidbody2D>().velocity = shotPower * ((Vector2)FirePoint.transform.position - (Vector2)Barrel.transform.position).normalized;
        timeSinceLastShot = 0;
    }
    void RandomShotPower()
    {
        shotPower = Random.Range(SHOT_MIN_POWER, SHOT_MAX_POWER);
        powerIncreasing = Random.Range(0f, 1f) >= 0.5f;
    }
    void PowerChange()
    {
        shotPower += SHOT_POWER_INCREMENT * (powerIncreasing ? 1f : -1f);
        if (shotPower >= SHOT_MAX_POWER)
            powerIncreasing = false;
        if (shotPower <= SHOT_MIN_POWER)
            powerIncreasing = true;
    }

    void UpdateDisplay()
    {
        switch (state)
        {
            case ShootingState.loading:
                PowerSlider.GetComponent<Slider>().fillRect.gameObject.GetComponent<Image>().color = Color.yellow;
                PowerSlider.GetComponent<Slider>().value = (shotPower - SHOT_MIN_POWER) / (SHOT_MAX_POWER- SHOT_MIN_POWER);
                break;
            case ShootingState.idle:
                PowerSlider.GetComponent<Slider>().fillRect.gameObject.GetComponent<Image>().color = Color.blue;
                PowerSlider.GetComponent<Slider>().value = 1f;
                break;
            case ShootingState.cooldown:
                PowerSlider.GetComponent<Slider>().fillRect.gameObject.GetComponent<Image>().color = Color.cyan;
                PowerSlider.GetComponent<Slider>().value = timeSinceLastShot / SHOT_COOLDOWN;
                break;

        }
    }
}

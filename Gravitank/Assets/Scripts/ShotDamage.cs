using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;

public class ShotDamage : MonoBehaviour
{
    float creationTime;
    float damage;
    Gradient colorGradient;
    void Start()
    {
        StartDamage();
        StartDisplay();
    }
    void Update()
    {
        UpdateDamage();
        UpdateDisplay();
    }
    // power of shooting matters
    public void ShotPowerToDamage(float power) =>
        damage += power * SHOT_DAMAGE_POWER_COEFFICIENT;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damageable")
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
    void StartDamage() => damage = SHOT_BASE_DAMAGE;
    void UpdateDamage()
    {
        if (damage < SHOT_MAX_DAMAGE)
            damage += SHOT_DAMAGE_TIME_COEFFICIENT;
    }
    void StartDisplay()
    {   
        colorGradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.white;
        colorKey[0].time = 0.0f;
        colorKey[1].color = new Color(0xFF, 0x80, 0x00); //orange
        colorKey[1].time = 1.0f;
        colorGradient.colorKeys = colorKey;
    }
    void UpdateDisplay() =>
       GetComponent<SpriteRenderer>().color = colorGradient.Evaluate(damage / SHOT_MAX_DAMAGE);
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Constants;
public class Health : MonoBehaviour
{
    public GameObject HealthSlider;
    float health;
    void Start()
    {
        health = MAX_HEALTH;
        UpdateDisplay();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) { EndGame(); }
        Debug.Log(health);
        UpdateDisplay();
    }
    void EndGame()
    {
        // UnityEngine.SceneManagement.SceneManager.LoadScene()
        Time.timeScale = 0;
        //co dál? tlačítko zpět na úvod zobrazit kdo vyhrál
    }
    void UpdateDisplay()
    {
        HealthSlider.GetComponent<Slider>().value = health / MAX_HEALTH;
    }
}

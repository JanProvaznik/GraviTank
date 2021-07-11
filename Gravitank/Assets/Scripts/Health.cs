using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    const float initialHealth = 100;
    float health;
    void Start()
    {
        health = initialHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) { EndGame();}
    }
    void EndGame()
    {
        // UnityEngine.SceneManagement.SceneManager.LoadScene()
        Time.timeScale=0;
        //co dál? tlačítko zpět na úvod zobrazit kdo vyhrál
    }
}

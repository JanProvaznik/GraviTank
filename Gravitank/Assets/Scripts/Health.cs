using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameInfo;
public class Health : MonoBehaviour
{
    public GameObject HealthSlider;
    float health;
    void Start()
    {
        health = MAX_HEALTH;
        UpdateDisplay();
    }
    // called by other objects that want to deal damage to this one
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) EndGame();
        UpdateDisplay();
    }
    void EndGame()
    {
        //the other one wins
        GameInfo.Player1Won = name == "Player2";
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }
    void UpdateDisplay() =>
        HealthSlider.GetComponent<Slider>().value = health / MAX_HEALTH;
}

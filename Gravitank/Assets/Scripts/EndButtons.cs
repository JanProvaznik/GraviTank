using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButtons : MonoBehaviour
{
    void Start() {
       
    }
    public void BeginGame()
    {
        GameInfo.Player1Name = GameObject.Find("Player1NameTextBox").GetComponent<InputField>().text;
        GameInfo.Player2Name = GameObject.Find("Player2NameTextBox").GetComponent<InputField>().text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    void ToWelcome()=>UnityEngine.SceneManagement.SceneManager.LoadScene("WelcomeScene");
    void Exit()=>Application.Quit();
}
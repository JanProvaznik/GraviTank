using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameInfo;

public class GUIEndScene : MonoBehaviour
{
    public Text WinnerText;
    public Button RestartButton;
    public Button ExitButton;
    void Start()
    {
        WinnerText.text = (Player1Won ? Player1Name : Player2Name) + " won!";
        RestartButton.onClick.AddListener(Restart);
        ExitButton.onClick.AddListener(Exit);
    }

    void Restart() =>
        UnityEngine.SceneManagement.SceneManager.LoadScene("WelcomeScene");
    void Exit() => Application.Quit();
}

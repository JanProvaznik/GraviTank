using UnityEngine;
using UnityEngine.UI;
using static GameInfo;

public class GUIWelcomeScene : MonoBehaviour
{

    public GameObject P1NameTextbox;
    public GameObject P2NameTextbox;
    public Button StartButton;
    void Start() =>
        StartButton.onClick.AddListener(BeginGame);

    public void BeginGame()
    {
        GameInfo.Player1Name = P1NameTextbox.GetComponent<InputField>().text;
        GameInfo.Player2Name = P2NameTextbox.GetComponent<InputField>().text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}

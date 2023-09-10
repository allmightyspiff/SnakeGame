using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI UsernameInput;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI Welcome;
    public GameObject UsernamePanel;
    private void Start()
    {
        Welcome.text = "Welcome " + MainManager.Instance.GetUsername();
        HighScore.text = "High Score: " + MainManager.Instance.GetHighscore()
                       + "\nLast Score: " + MainManager.Instance.GetLastScore()
                       + "\nGames: " + MainManager.Instance.GetGamesPlayed();
    }

    public void StartGame()
    {
        MainManager.Instance.UpdateGamesPlayed();
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void UsernameButton()
    {
        MainManager.Instance.UpdateUsername( UsernameInput.text);
        Welcome.text = "Welcome " + UsernameInput.text;
        UsernamePanel.SetActive(false);
    }

    public void SettingsButton()
    {
        UsernamePanel.SetActive(true);
    }
}

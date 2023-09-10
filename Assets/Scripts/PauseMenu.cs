using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public PlayerController thePlayer;
    public GameObject pauseMenu;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                ResueGame();
            } else {
                PauseGame();
            }
        }
    }

    public void QuitGame()
    {
        MainManager.Instance.UpdateHighscore(thePlayer.GetPoints());
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResueGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        MainManager.Instance.UpdateHighscore(thePlayer.GetPoints());
        ResueGame();
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject Level;
    [SerializeField] private GameObject LevelBar;


    public GameObject pauseMenuUI;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        LevelBar.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        LevelBar.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Levels()
    {
        Level.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
}

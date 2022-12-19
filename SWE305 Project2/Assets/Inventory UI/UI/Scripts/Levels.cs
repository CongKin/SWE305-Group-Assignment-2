using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Level;

    public GameObject pauseMenuUI;
    
    public void Level1(){
        SceneManager.LoadScene("Level1");
    }

    public void Level2(){
        SceneManager.LoadScene("Level2");
    }
    public void Level3(){
        SceneManager.LoadScene("Level3");
    }
    public void Level4(){
        SceneManager.LoadScene("Level4");
    }
    public void Level5(){
        SceneManager.LoadScene("Level5");
    }

    public void BackMenu(){
        Level.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackPause(){
        Level.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}

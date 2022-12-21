using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Level;
    [SerializeField] private GameObject Setting;

    
    public void PlayGame(){
        SceneManager.LoadScene("MainLevel");
    }

    public void Settings(){
        Setting.SetActive(true);
        Menu.SetActive(false);
    }

    public void ExitGame(){
        Debug.Log("Exit");
        Application.Quit();
    }
}

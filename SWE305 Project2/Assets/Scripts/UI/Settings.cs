using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Setting;
    
    public void Back(){
        Setting.SetActive(false);
        Menu.SetActive(true);
    }
}

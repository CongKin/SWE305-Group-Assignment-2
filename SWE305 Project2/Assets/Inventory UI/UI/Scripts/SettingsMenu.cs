using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static SettingsMenu instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    public void setVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void setFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}

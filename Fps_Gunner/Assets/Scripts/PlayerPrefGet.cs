using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefGet : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Resoulation", 0);
        Screen.SetResolution(1920, 1080, true);
        PlayerPrefs.SetInt("Quality", 0);
        QualitySettings.SetQualityLevel(2);
        Screen.fullScreen = true;
        PlayerPrefs.SetFloat("MouseSensitivity", 300);
        PlayerPrefs.SetFloat("MasterVolume", 0);
        PlayerPrefs.SetFloat("MusicVolume", 0);
        PlayerPrefs.SetInt("HighScore", 0);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //isFullScreen
    private bool isFullScreenMode;
    //Audio
    public AudioMixer audioMix;

    public void SetResoulation(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080, isFullScreenMode);
        }
        else if (index == 1)
        {
            Screen.SetResolution(1440, 900, isFullScreenMode);
        }
        else if (index == 2)
        {
            Screen.SetResolution(1280, 1024, isFullScreenMode);
        }
        else if (index == 3)
        {
            Screen.SetResolution(1280, 800, isFullScreenMode);
        }
        else if (index == 4)
        {
            Screen.SetResolution(1024, 768, isFullScreenMode);
        }
        else if (index == 5)
        {
            Screen.SetResolution(800, 600, isFullScreenMode);
        }
    }
    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex == 0)
            QualitySettings.SetQualityLevel(2); //Project Setting Quailty Levels
        else if (qualityIndex == 1)
            QualitySettings.SetQualityLevel(1); //Project Setting Quailty Levels
        else if (qualityIndex == 2)
            QualitySettings.SetQualityLevel(0); //Project Setting Quailty Levels
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFullScreenMode = isFullScreen;
    }

    public void SetMouseSensitivity(float senseValue)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", senseValue);
    }
    public void SetMasterVolume(float masterValue)
    {
        audioMix.SetFloat("MasterVolume", masterValue);
    }
    public void SetMusicVolume(float masterValue)
    {
        audioMix.SetFloat("MusicVolume", masterValue);
    }
}

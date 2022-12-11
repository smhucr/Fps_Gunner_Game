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
            PlayerPrefs.SetInt("Resoulation", 0);
            Screen.SetResolution(1920, 1080, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
        else if (index == 1)
        {
            PlayerPrefs.SetInt("Resoulation", 1);
            Screen.SetResolution(1440, 900, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
        else if (index == 2)
        {
            PlayerPrefs.SetInt("Resoulation", 2);
            Screen.SetResolution(1280, 1024, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
        else if (index == 3)
        {
            PlayerPrefs.SetInt("Resoulation", 3);
            Screen.SetResolution(1280, 800, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
        else if (index == 4)
        {
            PlayerPrefs.SetInt("Resoulation", 4);
            Screen.SetResolution(1024, 768, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
        else if (index == 5)
        {
            PlayerPrefs.SetInt("Resoulation", 5);
            Screen.SetResolution(800, 600, isFullScreenMode);
            Screen.fullScreen = isFullScreenMode;
        }
    }
    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex == 0)
        {
            PlayerPrefs.SetInt("Quality", 0);
            QualitySettings.SetQualityLevel(2); //Project Setting Quailty Levels
        }

        else if (qualityIndex == 1)
        {
            PlayerPrefs.SetInt("Quality", 1);
            QualitySettings.SetQualityLevel(1); //Project Setting Quailty Levels
        }
        else if (qualityIndex == 2)
        {
            PlayerPrefs.SetInt("Quality", 2);
            QualitySettings.SetQualityLevel(0); //Project Setting Quailty Levels
        }

    }

    public void SetFullScreen(bool isFullScreen)
    {
        if (isFullScreen)
            PlayerPrefs.SetInt("isFullScreen", 1);
        else
            PlayerPrefs.SetInt("isFullScreen", 0);
        Screen.fullScreen = isFullScreen;
        isFullScreenMode = isFullScreen;
    }

    public void SetMouseSensitivity(float senseValue)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", senseValue);
    }
    public void SetMasterVolume(float masterValue)
    {
        PlayerPrefs.SetFloat("MasterVolume", masterValue);
        audioMix.SetFloat("MasterVolume", masterValue);
    }
    public void SetMusicVolume(float masterValue)
    {
        PlayerPrefs.SetFloat("MusicVolume", masterValue);
        audioMix.SetFloat("MusicVolume", masterValue);
    }
    public void SetGravityVolume(float gravityValue)
    {
        float gravityRegulator = 150 - gravityValue;
        PlayerPrefs.SetFloat("Gravity", gravityRegulator);
    }
}

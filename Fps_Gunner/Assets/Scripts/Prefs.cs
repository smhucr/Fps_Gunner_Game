using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Prefs : MonoBehaviour
{
    //Player.Prefs ayarlari otomatik atanmaiyor otomatik hale getircez
    //Audio
    public AudioMixer audioMix;
    //Slider
    public Slider musicVolume;
    public Slider masterVolume;
    public Slider sensitivity;
    //DropDowns
    // public GameObject screenDropDown1;
    // public GameObject qualityDropDown1;
    public TMP_Dropdown screenDropDown; //using TMPro
    public TMP_Dropdown qualityDropDown; //using TMPro
    //Toggle
    public Toggle isFullScreen;
    private void Start()
    {

        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume", 0);
        sensitivity.value = PlayerPrefs.GetFloat("MouseSensitivity", 300);
        if (PlayerPrefs.GetInt("isFullScreen", 1) == 1)
            isFullScreen.isOn = true;
        else
            isFullScreen.isOn = false;
        //  screenDropDown1.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Resoulation", 0); //DropDown - TextMeshPro Oldugu icin calismiyor, DropDown olsaydi gorsel kotu
        //  qualityDropDown1.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Quality", 0); //DropDown - TextMeshPro Oldugu icin calismiyor, DropDown olsaydi gorsel kotu
        //  Bunlar Aslinda sorunu cozuyor
        screenDropDown.value = PlayerPrefs.GetInt("Resoulation", 0);//Solved
        qualityDropDown.value = PlayerPrefs.GetInt("Quality", 0); //Solved
    }

}

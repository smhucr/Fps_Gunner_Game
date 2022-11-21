using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //MainMenu Buttons
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject optionsButton;
    //Cameras
    public GameObject CutSceneCamera;
    public GameObject CanvasCamera;
    //MainMenu
    public GameObject MainMenuUI;
    //SettingsMenu
    public GameObject OptionsMenuUI;
    public void PlayGameButton()
    {
        StartCoroutine(PlayAfterLoadMainGame());
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void OptionsMenuButton()
    {
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void BackToMenuButton()
    {   
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    IEnumerator PlayAfterLoadMainGame()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        optionsButton.SetActive(false);
        CutSceneCamera.SetActive(true);
        CanvasCamera.SetActive(false);

        yield return new WaitForSeconds(31f);
        SceneManager.LoadScene(1);
    }

}

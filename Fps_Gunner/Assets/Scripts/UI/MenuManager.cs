using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //MainMenu Buttons
    public GameObject resumeButton;
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
    //AfterPlayResumeButton
    public GameObject afterPlayResume;
    //Story Panel
    public GameObject storyPanel;

    private void Start()
    {
        
        // PlayerPrefs.DeleteKey("isPlayed");//Deletes Resume Key
         
        if (PlayerPrefs.GetInt("isPlayed") == 3)
            resumeButton.SetActive(true);

        else
            resumeButton.SetActive(false);
    }


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

    public void ResumePlayGame()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator PlayAfterLoadMainGame()
    {
        storyPanel.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        resumeButton.SetActive(false);
        optionsButton.SetActive(false);
        CutSceneCamera.SetActive(true);
        CanvasCamera.SetActive(false);
        if (PlayerPrefs.GetInt("isPlayed") == 3)
            afterPlayResume.SetActive(true);

        yield return new WaitForSeconds(31f);
        PlayerPrefs.SetInt("isPlayed", 3);
        SceneManager.LoadScene(1);
    }

}

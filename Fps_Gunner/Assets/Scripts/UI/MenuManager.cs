using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject CutSceneCamera;
    public GameObject CanvasCamera;
    public void PlayGameButton()
    {
        StartCoroutine(PlayAfterLoadMainGame());
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    IEnumerator PlayAfterLoadMainGame()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        CutSceneCamera.SetActive(true);
        CanvasCamera.SetActive(false);

        yield return new WaitForSeconds(31f);
        SceneManager.LoadScene(1);
    }
}

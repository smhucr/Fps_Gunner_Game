using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Paused
    private bool isGamePaused = false;
    //Pause Menu
    public GameObject pauseMenuUI;
    //GameOver
    public bool isGameOver = false;
    //Disable Objects
    private GameObject player;
    private GameObject pistol;
    //CrossHair Bool
    public GameObject crossHair;
    //Music
    public AudioSource music;
    //Settings Menu
    public GameObject settingsMenuUI;
    //Regular UI Objects
    public GameObject hitScore;
    public GameObject timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pistol = GameObject.FindGameObjectWithTag("Pistol");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        //Stop
        Time.timeScale = 0;
        isGamePaused = true;
        //Pause Music
        music.Pause();
        //Disable Player
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<JumpAndGravity>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;
        //Disable CrossHair
        crossHair.SetActive(false);
        //Cursor Mode
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //Menu
        pauseMenuUI.SetActive(true);
    }
    public void Resume()
    {
        //Contiune
        Time.timeScale = 1;
        isGamePaused = false;
        //Contiune Music
        music.UnPause();
        //Enable Player
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<JumpAndGravity>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;
        //Disable CrossHair
        crossHair.SetActive(true);
        //Cursor Mode
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Menu
        pauseMenuUI.SetActive(false);
        //Control Unit
        settingsMenuUI.SetActive(false);
        hitScore.SetActive(true);
        timer.SetActive(true);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void SettingsMenu()
    {
        hitScore.SetActive(false);
        timer.SetActive(false);
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);

    }

    public void BackToPauseMenu()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        hitScore.SetActive(true);
        timer.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

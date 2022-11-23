using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManage : MonoBehaviour
{
    //ScoreCalculate
    [HideInInspector]
    public int score;
    public int bulletCount;
    private float timer;
    //HighScore
    private int highScore;
    public Text lastScoreScreen;
    public float lastScoreCalculate;
    public GameObject scoreTextUI;
    //HitScore
    public Text txt;
    //ControlUnit
    public bool isComplete = false;
    public bool oneDo = false;
    public bool playerAlive;

    private void Start()
    {
        playerAlive = true;
        bulletCount = 1;
    }
    private void Update()
    {
        if (playerAlive)
            txt.text = "Hit Score : " + score.ToString();
        else
        {
            if (!oneDo)
            {
                //ChangetoScoreMode
                scoreTextUI.SetActive(true);
                timer = GameObject.FindGameObjectWithTag("Text").GetComponent<UITexts>().timer;
                highScore = FinalScore();
                oneDo = true;
                isComplete = true;
            }

        }
        if (isComplete)
        {
            lastScoreCalculate += Time.deltaTime * 70 * bulletCount;//Increase Score slowy
            lastScoreScreen.text = "Your Score : " + ((int)lastScoreCalculate).ToString();
            if (lastScoreCalculate > highScore)
            {
                isComplete = false;
                lastScoreScreen.text = "Your Score : " + highScore.ToString();
            }

        }

    }

    private int FinalScore()
    {
        int lastScore;
        int timerTemp;
        if (timer > 30)
        {
            timerTemp = (int)timer / 30;
            lastScore = score * 69 / bulletCount / timerTemp;
        }
        else
        {
            lastScore = score * 69 / bulletCount / (int)timer;
        }



        return lastScore;
    }

    //Button Menus
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCalculate : MonoBehaviour
{
    public Text winScoreText;
    private float winScoreCalculate;
    private int highScore;
    private bool isEnough = true;
    [SerializeField]
    private int bulletCount = 1;
    private int winScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        if (isEnough)
        {
            winScoreCalculate += Time.deltaTime * 70 * bulletCount;//Increase Score slowy
            winScoreText.text = "Your Score : " + ((int)winScoreCalculate).ToString();
            if (winScoreCalculate > highScore)
            {
                isEnough = false;
                winScoreText.text = "Your Score : " + highScore.ToString();
            }
        }
    }

    private void OnEnable()
    {
        winScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().score;
        int lastScore;
        lastScore = winScore;
        if (winScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", lastScore);
        }
        bulletCount = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().bulletCount;
    }
}

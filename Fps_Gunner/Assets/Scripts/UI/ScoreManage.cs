using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    [HideInInspector]
    public int score;
    public Text txt;
    public bool playerAlive;

    private void Start()
    {
        playerAlive = true;
    }
    private void Update()
    {
        if (playerAlive)
            txt.text = score.ToString();
    }
}

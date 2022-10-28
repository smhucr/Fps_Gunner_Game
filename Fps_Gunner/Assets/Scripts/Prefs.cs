using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    public float scoreCalculate;
    private GameObject dragon;


    private void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        scoreCalculate = 0;
    }

    private void Update()
    {
        if (!dragon.GetComponent<BossAI>().isBossAlive)
        {
            PlayerPrefs.SetInt("HighScore", (int)scoreCalculate);
        }
    }
}

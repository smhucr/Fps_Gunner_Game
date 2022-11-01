using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    public float scoreCalculate;
    [SerializeField]
    private bool isDragonAlive = false;


    private void Start()
    {
        
        scoreCalculate = 0;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Dragon").GetComponent<BossAI>().isBossAlive)
        {
            isDragonAlive = true;
            PlayerPrefs.SetInt("HighScore", (int)scoreCalculate);
        }
    }
}

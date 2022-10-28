using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITexts : MonoBehaviour
{
    public float timer;
    public Text txt;
    int currentTime;
    public bool isGameContinue;
    private void Start()
    {
        isGameContinue = true;
    }

    private void Update()
    {
        if (isGameContinue)
        {
            timer += Time.deltaTime;
            currentTime = (int)timer;
            txt.text = currentTime.ToString();
        }

    }
}

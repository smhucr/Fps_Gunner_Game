using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishUI : MonoBehaviour
{
    public GameObject winScreen;
    public bool isGameFinish = false;
    public void FinishScreenAprove()
    {
        winScreen.SetActive(true);
        isGameFinish = true;
    }


}

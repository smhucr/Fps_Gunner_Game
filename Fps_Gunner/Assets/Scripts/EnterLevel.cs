using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager Lm;
    public bool enter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enter)
            {
                Lm.player_Enter = true;
            }
            else
            {
                Lm.player_exit = true;
            }
        }   
    }
}

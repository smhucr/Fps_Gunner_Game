using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager Lm;
    public bool enter;
    public int counterForLevels;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enter)
            {
                if (!Lm.player_Enter)
                    other.GetComponent<PlayerManager>().counter++;
                Lm.player_Enter = true;
                counterForLevels = other.GetComponent<PlayerManager>().counter;
                if (counterForLevels >= 5)
                    Lm.isCountFive = true;
                if (counterForLevels == 10)
                    Lm.isCountTen = true;
                if (counterForLevels >= 11)
                    Lm.isCountEleven = true;
            }
            else
            {
                Lm.player_exit = true;
            }
            if(other.GetComponent<PlayerManager>().tempWall != null)
            {
                Destroy(other.GetComponent<PlayerManager>().tempWall);
            }

        }

    }
}

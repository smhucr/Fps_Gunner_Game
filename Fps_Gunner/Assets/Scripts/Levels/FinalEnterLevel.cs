using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnterLevel : MonoBehaviour
{
    public FinalManager FinalMan;
    public bool enter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enter)
            {
                //FinalManage
                if (!FinalMan.player_Enter)
                {
                    FinalMan.player_Enter = true;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().isBossLeveled = true;
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<PauseMenu>().bossHealthBar.SetActive(true);
                }



            }

        }

    }
}

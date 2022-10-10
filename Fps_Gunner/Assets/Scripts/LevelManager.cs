using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player enter exit
   public bool player_Enter, player_exit;

    //Drone Spawn 
    private bool isDrone_spawned;

    public Transform[] drone_Spawners;
    public GameObject drone;

    private void Update()
    {

        //drone spawn
        if (!isDrone_spawned)
        {
            if (player_Enter)
            {
                for (int i = 0; i < drone_Spawners.Length-Random.Range(0,drone_Spawners.Length-1); i++)
                    Instantiate(drone, drone_Spawners[i].position, Quaternion.identity);
                isDrone_spawned = true; 
            }
        }
    }

}

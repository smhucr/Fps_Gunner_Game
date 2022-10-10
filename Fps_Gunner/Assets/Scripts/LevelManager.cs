using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player enter exit
    public bool player_Enter, player_exit;

    //Drone Spawn 
    private bool isSpawned;

    public Transform[] drone_Spawners;
    public GameObject drone;

    //Level Spawn
    public GameObject[] level;
    public GameObject destroy_Level;

    private void Awake()
    {
        player_Enter = false;
        isSpawned = false;
    }
    private void Update()
    {

        //drone spawn
        if (!isSpawned)
        {
            if (player_Enter)
            {
                for (int i = 0; i < drone_Spawners.Length - Random.Range(0, drone_Spawners.Length - 1); i++)
                    Instantiate(drone, drone_Spawners[i].position, Quaternion.identity);
                isSpawned = true;
            }
        }



    }
    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100);
        Instantiate(level[Random.Range(0, level.Length)], pos, Quaternion.identity);
    }

}

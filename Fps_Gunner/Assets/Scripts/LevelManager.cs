using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //CounterChecker
    public bool isCountFive = false, isCountTen = false, isCountEleven = false;

    //Player enter exit
    public bool player_Enter, player_exit;

    //Drone Spawn 
    public bool isSpawned;
    public Transform[] drone_Spawners;
    public GameObject drone;

    //Wall Spawn
    public GameObject closing_Wall_Normal;
    public GameObject closing_Wall_Turned;
    Vector3 pos_behind, pos_front;
    GameObject wall_behind, wall_front;

    //Level Spawn
    public GameObject[] level;
    public GameObject destroy_Level;
    public GameObject finalLevel;

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
                //Drone spawn
                for (int i = 0; i < drone_Spawners.Length - Random.Range(0, drone_Spawners.Length - 1); i++)
                    Instantiate(drone, drone_Spawners[i].position, Quaternion.identity);

                //Spawn Level
                if (!isCountEleven)
                {
                    if (!isCountTen)
                    {
                        SpawnLevel();
                    }

                    else if (isCountTen)
                    {
                        SpawnFinalLevel();
                    }
                }
                //set bool
                isSpawned = true;

                //Spawn Walls
                pos_front = new Vector3(transform.position.x + 30, transform.position.y + 50, transform.position.z + 680);
                pos_behind = new Vector3(transform.position.x + 30, transform.position.y + 50, transform.position.z - 220);
                wall_behind = Instantiate(closing_Wall_Turned, pos_behind, Quaternion.identity);
                wall_front = Instantiate(closing_Wall_Normal, pos_front, Quaternion.identity);

            }

        }
        //Destroy Level
        if (player_exit)
        {
            if (destroy_Level != null)
            {
                DestroyLevel();
            }
            StartCoroutine(WaitForDestroy());

        }
    }
    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 500);
        GameObject new_Level = Instantiate(level[Random.Range(0, level.Length)], pos, Quaternion.identity * Quaternion.Euler(new Vector3(0, 180, 0)));
        new_Level.GetComponent<LevelManager>().destroy_Level = this.gameObject;

    }
    private void SpawnFinalLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 528);
        GameObject new_Level = Instantiate(finalLevel, pos, Quaternion.identity);
    }

    private void DestroyLevel()
    {
        Destroy(destroy_Level);


    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(wall_front);
        Destroy(wall_behind);
    }

}

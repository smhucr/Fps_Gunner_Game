using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfLevelSpawn : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject StartArea;

    private void Start()
    {
        //Spawn Start Area
        Vector3 firstpos = new Vector3(0, 25, -94);
        Instantiate(StartArea, firstpos, Quaternion.identity);

        //Spawn Walls
        Vector3 pos_front = new Vector3(30, 50, 580);
        Vector3 pos_behind = new Vector3(30, 50, 0);

        //Spawn Normal Level
        Vector3 startpos = new Vector3(0, 0, 0);
        for (int i = 0; i < levels.Length; i++)
        {
            GameObject new_Level = Instantiate(levels[Random.Range(0, levels.Length)], startpos, Quaternion.identity * Quaternion.Euler(new Vector3(0, 180, 0)));
            new_Level.GetComponent<LevelManager>().player_Enter = false;
            new_Level.GetComponent<LevelManager>().isSpawned = false;
            startpos += new Vector3(0, 0, 100);
        }



    }


}

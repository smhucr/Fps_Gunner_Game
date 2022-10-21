using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    //Dragon
    public GameObject bossDragon;
    //ControlUnit
    [SerializeField]
    private bool isPlayed = false;
    [SerializeField]
    private bool isStartable = false;
    [SerializeField]
    private bool isCanDo = true;

    private bool oneDo = true;
    //Player enter exit
    public bool player_Enter;

    //Drone Spawn 
    public Transform[] drone_Spawners;
    public GameObject drone;

    //CloseWall
    public GameObject backWall;

    private void Update()
    {
        if (player_Enter)
        {
            if (oneDo)
            {
                bossDragon.SetActive(true);
                backWall.SetActive(true);
                oneDo = false;
            }
            if (isCanDo)
            {
                if (!isPlayed)
                {
                    StartCoroutine(WaitForStarting());
                }
                if (isStartable)
                {
                    StartCoroutine(DroneSpawn());
                }
            }   
        }
    }
    IEnumerator WaitForStarting()
    {
        yield return new WaitForSeconds(6f);
        isPlayed = true;
        isStartable = true;
    }
    IEnumerator DroneSpawn()
    {
        isCanDo = false;
        //Drone spawn
        for (int i = 0; i < drone_Spawners.Length - Random.Range(0, drone_Spawners.Length - 1); i++)
            Instantiate(drone, drone_Spawners[i].position, Quaternion.identity);
        yield return new WaitForSeconds(15f);
        isCanDo = true;
    }
}

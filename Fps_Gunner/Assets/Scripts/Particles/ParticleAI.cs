using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAI : MonoBehaviour
{
    //PlayerPosition
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //ParticleRotation To Player
        transform.LookAt(player.position);
    }
}

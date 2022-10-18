using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAI : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(player.position);
    }
}

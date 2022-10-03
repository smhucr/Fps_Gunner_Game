using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public ParticleSystem impactEffect;
    public LayerMask player_layer;
    private bool isGround;
    public Transform groundChecker;
    public Transform impactChecker;
    private float groundCheckerRadius = 0.1f;
    public LayerMask obstacleLayer;
    public float impactRadius = 4f;
    private bool is_Boom = true;
    private bool afterImpact = false;

    private void Update()
    {
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);
        afterImpact = Physics.CheckSphere(impactChecker.position, impactRadius,player_layer);
        if (isGround && is_Boom)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            
            if (afterImpact)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
                
            }
            Destroy(this.gameObject);
            is_Boom = false;
            
        }
        
    }
}

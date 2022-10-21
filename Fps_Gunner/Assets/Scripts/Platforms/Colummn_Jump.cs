using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colummn_Jump : MonoBehaviour
{
    //If this script wasn't
    //Player  cant jump on Collummn When It is falling
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<JumpAndGravity>().inCollumn = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<JumpAndGravity>().inCollumn = false;
        }
    }
}

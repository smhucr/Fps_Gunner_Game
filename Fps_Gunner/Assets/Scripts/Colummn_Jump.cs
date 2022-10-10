using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colummn_Jump : MonoBehaviour
{
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

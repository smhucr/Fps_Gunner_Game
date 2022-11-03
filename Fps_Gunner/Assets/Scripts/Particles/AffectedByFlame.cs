using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByFlame : MonoBehaviour
{
    //When Particle Hits Player doing something
    private void OnParticleCollision(GameObject other)
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().score -= 5;
    }
}

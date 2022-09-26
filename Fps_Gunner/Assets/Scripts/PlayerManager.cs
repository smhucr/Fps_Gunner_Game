using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isPlayer_alive = true;
    public ParticleSystem death_effect;
    public void Death()
    {
        if (isPlayer_alive)
        {
            isPlayer_alive = false;
            //Particle effect 
            Instantiate(death_effect, transform.position, Quaternion.identity);
        }
    }
}
    
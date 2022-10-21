using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isPlayer_alive = true;
    public ParticleSystem death_effect;
    //Disable Object
    public GameObject hand;
    public GameObject crossHair;
    //Counter
    public int counter = 0;
    //tempWallDestroy
    public GameObject tempWall;

    
    public void Death()
    {
        if (isPlayer_alive)
        {
            //Set Alive
            isPlayer_alive = false;
            //Particle effect 
            Instantiate(death_effect, transform.position, Quaternion.identity);
            /*
            //Disable Player
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<JumpAndGravity>().enabled = false;
            GetComponent<CameraController>().enabled = false;
            hand.SetActive(false);
            crossHair.SetActive(false);

            //Cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            */
            
        }
    }
    
}

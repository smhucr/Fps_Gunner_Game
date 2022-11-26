using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlCutScene : MonoBehaviour
{

    //Layers
    public LayerMask obstacleLayer;

    //RaycastStats
    RaycastHit hit;
    private float range = 300f;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacleLayer)) //range yerine Mathf.Infinity Kullanilabilir
        {
            //Laser Olusumu
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.15f + Mathf.Sin(Time.time) / 60;

        }
        else
        {
            //Raycast Cant Collide with obstacle
            GetComponent<LineRenderer>().enabled = false;
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacleLayer;
    public LayerMask player_Layer;
    private float range = 100f;
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacleLayer)) //range yerine Mathf.Infinity Kullanilabilir
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.15f + Mathf.Sin(Time.time) / 60;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_Layer))
            {
                //Eger lazer cikmiyorsa adam olmez buda kesin lazere olum oluyor
                hit.transform.gameObject.GetComponent<PlayerManager>().Death();

            }
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }


    }

}

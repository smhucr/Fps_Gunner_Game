using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacleLayer;
    public LayerMask player_Layer;
    private Vector3 far, far1;
    private float farCalculator, farCalculator2;
    private float range = 130f;
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacleLayer)) //range yerine Mathf.Infinity Kullanilabilir
        {
            //Laser Olusumu
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.15f + Mathf.Sin(Time.time) / 60;

            //Fizik 2 nokta arasi uzaklik formulu
            far = GetComponent<LineRenderer>().GetPosition(1) - GetComponent<LineRenderer>().GetPosition(0);
            far1 = GameObject.FindGameObjectWithTag("Player").transform.position - GetComponent<LineRenderer>().GetPosition(0);
            farCalculator = far.sqrMagnitude;
            farCalculator2 = far1.sqrMagnitude;


            if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_Layer) && farCalculator > farCalculator2)
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

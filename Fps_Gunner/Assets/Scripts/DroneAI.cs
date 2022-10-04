using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    //Player
    private Transform player;
    //Distance
    private float follow_distance = 20f;
    //Follow
    private float follow_speed = 10f;
    //Rotate
    private float rotate_speed = 4f;
    //Timer
    private float coolDown = 2f;
    //Drone //2 kez drone icinde drone yapiyoruz cunku animasyon kodlarý durduruyor
    public GameObject droneEnemy;
    public GameObject droneBullet;
    public GameObject firePoint;
    //Drone Health
    public float health = 100f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();
        Shoot();
        droneDeath();
    }

    private void FollowPlayer()
    {
        //Drone Look Player
        transform.LookAt(player.position);
        // transform.rotation *= Quaternion.Euler(new Vector3(0,0,0)); // offset ayarý eger drone duzgun bakmassa
        //Drone Moving to Player
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            //transform.Translate(transform.forward * Time.deltaTime * follow_speed * -1); burda ziplayinca drone assagi iniyor hatali
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * follow_speed); // tamamiyle takip ediyor
        }
        else
        {
            transform.RotateAround(player.position, new Vector3(0, 1, 0), Time.deltaTime * follow_speed * rotate_speed); // 2. parametre transform.forward hatali
        }
    }

    private void Shoot()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        else
        {
            coolDown = 2f;
            //Shot
            droneEnemy.GetComponent<Animator>().SetTrigger("Shoot");
            Instantiate(droneBullet, firePoint.transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0))); //firepoint kullanma sebebi drone da obstacle bundan dolayi collision engelliyor
        }
    }
    public void droneDeath()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

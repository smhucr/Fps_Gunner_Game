using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //BulletStats
    private float speed = 90f;
    public float lifetime = 5f;
    //Particle
    public ParticleSystem metal_hit_effect;

    private void Update()
    {
        //BulletSpeedAndLifetime
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {


        //When hit enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject Enemy = other.transform.gameObject;
            Enemy.GetComponent<EnemyHealth>().enemyHealth -= 25f;
        }
        if (other.CompareTag("Drone"))
        {
            GameObject droneEnemy = other.transform.parent.gameObject;
            droneEnemy.GetComponent<DroneAI>().health -= 25f;
        }
        if (other.CompareTag("Dragon"))
        {
            GameObject dragonEnemy = other.transform.gameObject;
            dragonEnemy.GetComponent<BossAI>().health -= 25;
        }


        //Hit
        Instantiate(metal_hit_effect, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0,90,0)));
        Destroy(this.gameObject);
    }
}

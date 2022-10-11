using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 90f;

    public float lifetime = 5f;

    public ParticleSystem metal_hit_effect;

    private void Update()
    {
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
            GameObject droneEnemy = other.transform.parent.gameObject;
            droneEnemy.GetComponent<DroneAI>().health -= 25f;
        }


        //Hit
        Instantiate(metal_hit_effect, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0,90,0)));
        Destroy(this.gameObject);
    }
}

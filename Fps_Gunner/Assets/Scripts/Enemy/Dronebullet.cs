using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dronebullet : MonoBehaviour
{
    //BulletStats
    private float speed = 30f;
    public float lifetime = 5f;
    public float radius = 0.5f;
    //BulletAim
    public LayerMask player_layer;
    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;
        //5 seconds after dead
        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }

        if (Physics.CheckSphere(transform.position, radius, player_layer)) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dronebullet : MonoBehaviour
{
    //PlayerBossLevel
    public bool isBossLevel = false;
    //BulletStats
    private float speed = 30f;
    public float lifetime = 5f;
    public float radius = 0.5f;
    //BulletAim
    public LayerMask player_layer;
    //Bool 1 time
    private bool isOneDo = true;
    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;
        //5 seconds after dead
        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }

        if (Physics.CheckSphere(transform.position, radius, player_layer))
        {
            if (!isBossLevel)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            else
            {
                if (isOneDo)
                {
                    GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().score -= 50;
                    isOneDo = false;
                }

            }
        }

    }
}

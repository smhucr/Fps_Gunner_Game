using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemies Health
    public float enemyHealth = 50f;
    //DeathParticle
    public GameObject particle;

    private void Update()
    {
        EnemyDead();
    }

    public void EnemyDead()
    {
        //HealthControl
        if(enemyHealth <= 0)
        {
            //Spawn Particles
            Instantiate(particle, gameObject.transform.position,Quaternion.identity);
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().score += 35;
            Destroy(this.gameObject);
        }
    }

}

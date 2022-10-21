using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemies Health
    public float enemyHealth = 50f;

    private void Update()
    {
        EnemyDead();
    }

    public void EnemyDead()
    {
        //HealthControl
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}

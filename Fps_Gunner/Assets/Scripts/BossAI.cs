using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //BossAI
    private Transform player;
    private float bossSpeed = 25f;
    private Vector3 startPos;
    private Vector3 endPos, temp;
    public bool isLeft, isRight;

    //Health
    public float health = 1000f;

    //Particle
    public GameObject fireBreath;

    //Offset
    public Vector3 offset;


    private void Start()
    {
        fireBreath.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = new Vector3(-130, -45, 200);
        endPos = new Vector3(70, -45, 200);
       // StartCoroutine(ComeandGo());
    }



    private void Update()
    {
        transform.LookAt(player.position + offset);

        if (gameObject.transform.position.x > endPos.x || isLeft)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * bossSpeed, Space.World);
            isLeft = true;
            isRight = false;
        }
        if (gameObject.transform.position.x < startPos.x || isRight)
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * bossSpeed, Space.World);
            isLeft = false;
            isRight = true;
        }
        BossDeath();
    }


    IEnumerator ComeandGo()
    {
        StartCoroutine(FireShoot());



        // transform.position = Vector3.Lerp(new Vector3(transform.position.x, -45, transform.position.z), new Vector3(transform.position.x, -45, transform.position.z), 5f);
        // Kullanmaya gerek yok
        yield return new WaitForSeconds(5f);

        StartCoroutine(ComeandGo());
    }

    IEnumerator FireShoot()
    {
        fireBreath.SetActive(true);
        yield return new WaitForSeconds(10f);
        fireBreath.SetActive(false);

    }

    private void BossDeath()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //BossAI
    private Transform player;
    private float bossSpeed = 25f;
    private Vector3 startPos;
    private Vector3 endPos;
    public bool isLeft, isRight;
    private bool isMoveable = true;
    //Health
    public float health = 1000f;

    //Particle
    public Transform firePos;
    public GameObject fireBreath;
    //Offset
    public Vector3 offset;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = new Vector3(-130, -45, 200);
        endPos = new Vector3(70, -45, 200);
        StartCoroutine(FireShoot());
    }



    private void Update()
    {
        transform.LookAt(player.position + offset);
        if (isMoveable)
        {
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
                print("sa");
            }
        }

        BossDeath();
    }

    IEnumerator FireShoot()
    {
        yield return new WaitForSeconds(10f);
        isMoveable = false;
        GameObject breath = Instantiate(fireBreath, firePos.position, Quaternion.identity);
        breath.transform.parent = gameObject.transform.GetChild(0);
        breath.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(MoveableControl());
        StartCoroutine(FireShoot());

    }

    IEnumerator MoveableControl()
    {
        yield return new WaitForSeconds(7f);
        isMoveable = true;
    }
    private void BossDeath()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

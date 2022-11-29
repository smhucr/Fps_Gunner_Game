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
    public int health = 1000;
    public bool isBossAlive;
    //FinalManagerStopper
    public FinalManager FM;
    //HealthBarScript
    public HealthBar HB;
    //Particle
    public Transform firePos;
    public GameObject fireBreath;
    //Offset
    public Vector3 offset;
    //Audio
    public AudioClip attackAuido;

    private void Start()
    {
        isBossAlive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = new Vector3(-130, -45, 200);
        endPos = new Vector3(70, -45, 200);
        HB = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        HB.SetMaxHealth(health);
        StartCoroutine(FireShoot());
    }



    private void Update()
    {
        //All script work on boss alive
        if (isBossAlive)
        {
            //Boss Look Player
            transform.LookAt(player.position + offset);
            if (isMoveable)
            {
                //MovementLeftRight
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
            }

            BossDeath();
        }
    }

    IEnumerator FireShoot() 
    {

        yield return new WaitForSeconds(10f);
        isMoveable = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(attackAuido, 0.7f);
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
            FM.isStopable = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<UITexts>().isGameContinue = false;
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().score += 20000;
            GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
            Destroy(this.gameObject);
        }
        HB.SetHealth(health);
    }

}

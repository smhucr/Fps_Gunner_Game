using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject hand;
    //Look
    public LayerMask obstacleLayer;
    public Vector3 offset;
    RaycastHit hit;
    //Fire
    public GameObject bullet;
    public Transform firePoint;
    //FireControl
    private float coolDown;
    public AudioClip gunShot;
    private void Update()
    {
        //Looking
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }
        //CoolDown
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        //Fire
        if (Input.GetMouseButtonDown(0) && (coolDown <= 0))
        {
            Instantiate(bullet, transform.position, transform.rotation); // transform.position yerine firepoint.position kullanýp offset ayarlarinda kucuk degisikler yapilabilir
            coolDown = 0.32f;
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManage>().bulletCount++;
            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot,0.5f);
            //Animation
            GetComponent<Animator>().SetTrigger("ShotTrigger");
        }
    }
}

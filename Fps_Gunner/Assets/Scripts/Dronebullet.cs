using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dronebullet : MonoBehaviour
{
    private float speed = 30f;

    public float lifetime = 5f;

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}

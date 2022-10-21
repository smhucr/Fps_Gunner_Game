using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour
{
    //RotateStats
    public Vector3 rotateAxis;
    public float speed;
    private void Update()
    {
        //Rotate
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}

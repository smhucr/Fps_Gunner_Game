using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //CameraStats
    public float sensitivity;
    private float xRotation = 0f;
    private void Start()
    {
        //CursorINVisible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //Sensitivity Changer
        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 200);
        //Camera Look
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        //Camera Border
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}

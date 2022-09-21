using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;
    private float xRotation = 0f;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}

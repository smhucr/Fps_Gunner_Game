using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndGravity : MonoBehaviour
{
    private CharacterController controller;
    public PlayerMovement pMove;
    private Vector3 velocity;
    private float gravity = -9.807f;
    private float gravityDivide = 100f;
    private float jumpHeight = 0.1f;
    public float jumpSpeed = 30f;
    private bool isGround;
    public Transform groundChecker;
    private float groundCheckerRadius = 0.1f;
    public LayerMask obstacleLayer;
    private float accTimer;
    private int x;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    private void Update()
    {
        
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);
        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            StartCoroutine(AfterJumpWaitOne());
            accTimer += Time.deltaTime;
            StopCoroutine(AfterJumpWaitOne());
        }
        else
        {

            velocity.y = 0f;
            pMove.speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide);
        }
        controller.Move(velocity);
    }
    IEnumerator AfterJumpWaitOne()
    {
        yield return new WaitForSeconds(1.7f);
        if (!isGround)
        {
            pMove.speed = Mathf.Lerp(5f, jumpSpeed, accTimer);

        }
        if (isGround)
        {
            //velocity.y = 0.1f; // Buradaki sahis obstacle objenin kosesine gelince autojump ozelligini aktif ediyor
            pMove.speed = 5f;
            accTimer = 0;
        }
    
    }
}

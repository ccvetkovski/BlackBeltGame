using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothieTime = 0.1f;
    float turnSmoothVelocity;
    private Animator anim;

    public float sprintSpeed = 9f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float horizontalMove = 0f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;
    bool isGrounded;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        horizontalMove = horizontal * speed;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothieTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    //public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothieTime = 0.1f;
    float turnSmoothVelocity;
    private Animator anim;

    public GameObject playerSwap;

    public float sprintSpeed = 9f;

    float horizontalMove = 0f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Rigidbody rb;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        horizontalMove = horizontal * speed;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothieTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity = new Vector3(10, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("Animation", 1); //Walk
        }
        else
        {
            anim.SetInteger("Animation", 0); //Idle
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(8, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-8, 0, 0);
        }



        velocity.y += gravity * Time.deltaTime;

    }

    public void PressurePolliwog()
    {
        rb.AddForce(0, 1000000, 0, ForceMode.Impulse);
        Debug.Log("Pressure Polliwog.");
    }

    public void UseAbility(AbilityManager.Ability whichAbility)
    {
        if(whichAbility == AbilityManager.Ability.PressurePolliwog)
        {
            PressurePolliwog();
            playerSwap.GetComponent<PlayerSwap>().Swap();
        }
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
}


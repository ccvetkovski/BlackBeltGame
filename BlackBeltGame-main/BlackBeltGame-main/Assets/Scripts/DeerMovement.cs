using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DeerMovement : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 6f;

    public AudioSource walk;
    //public float turnSmoothieTime = 0.1f;
    float turnSmoothVelocity;
    public Animator anim;

    public GameObject playerSwap;

    public float sprintSpeed = 9f;

    public float rotSpeed = 2f;

    public HealthSystem hs;

    float horizontalMove = 0f;
    public float jumpHeight = 3f;
    public BoxCollider boxCol;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Rigidbody playerRB;

    public PlayerSwap swap;

    [Header("Variables for Abilities")]
    
    public GameObject tongue;

    public BoxCollider tongueCol;

    public GameObject foulFangs;

    public BoxCollider fangsObj;
    
    public bool isJumping = false;


    Vector3 direction = new Vector3(0f, 0f, 0f);

    float SlerpTime=0;

    public TongueTrap tongueCode;

    public FoulFangs fangsCode;

    public PhantomProwl prowlCode;

    public BlitzBurst blitzCode;

    int LastInputDirection;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontalMove = horizontal * speed;


        float vy = playerRB.velocity.y;
        Vector3 move = new Vector3(-horizontal, 0, -vertical);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

            playerRB.velocity = new Vector3((move*speed).x, vy , (move * speed).z);

            anim.SetBool("isWalking", true); //Walk
            walk.enabled = true;
            //gameObject.transform.  = gameObject.transform.position + transform.forward * speed;
        }
        else
        { 
            playerRB.velocity = new Vector3(0, vy, 0);

            anim.SetBool("isWalking", false); //Walk
            walk.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            playerRB.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && anim.GetBool("onAir") == true)
        {
            anim.SetTrigger("landTrigger");
            anim.SetBool("onAir", false); 
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }


    public void PressurePolliwog(Rigidbody playerRB)
    {
        anim.SetBool("onAir", true);
        swap.switchCharacter(); 
        playerRB.AddForce(0, 15, 0, ForceMode.Impulse);
        anim.SetTrigger("jumpTrigger");
    }

    public void TongueTrap(Rigidbody playerRB)
    {
        Debug.Log("Tongue Trap");
        swap.switchCharacter(); 
        tongue.SetActive(true); 
        tongueCode.waitTimer = 3; 
    }

    public void FoulFangs(Rigidbody playerRB)
    {
        Debug.Log("Foul Fangs");
        swap.switchCharacter(); 
        foulFangs.SetActive(true); 
        fangsCode.waitTimer = 3;
    }

    public void PhantomProwl(Rigidbody playerRB)
    { 
        Debug.Log("Phantom Prowl"); 
        swap.switchCharacter(); 
        prowlCode.waitTimer = 10;
    }    

    public void BlitzBurst(Rigidbody playerRB)
    { 
        Debug.Log("Blitz Burst"); 
        swap.switchCharacter(); 
        blitzCode.waitTimer = 5;
    }

    public void UseAbility(AbilityManager.Ability whichAbility)
    {
        if (whichAbility == AbilityManager.Ability.PressurePolliwog)
        {
            PressurePolliwog(playerRB);
            playerSwap.GetComponent<PlayerSwap>().Swap();
        }
        if (whichAbility == AbilityManager.Ability.TongueTrap)
        {
            TongueTrap(playerRB);
            playerSwap.GetComponent<PlayerSwap>().Swap();
        }
        if (whichAbility == AbilityManager.Ability.FoulFangs)
        {
            FoulFangs(playerRB);
            playerSwap.GetComponent<PlayerSwap>().Swap();
        }
        if (whichAbility == AbilityManager.Ability.PhantomProwl) 
        { 
            PhantomProwl(playerRB); 
            playerSwap.GetComponent<PlayerSwap>().Swap(); 
        }
        if (whichAbility == AbilityManager.Ability.BlitzBurst)
        {
            BlitzBurst(playerRB);
            playerSwap.GetComponent<PlayerSwap>().Swap();
        }
    }

    public void Slam()
    {
        playerRB.AddForce(0, -20, 0, ForceMode.Impulse);
        hs.damage = 100;
        Debug.Log(hs.damage);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 6f;
    public float turnSmoothieTime = 0.1f;
    float turnSmoothVelocity;
    public Animator anim;

    public GameObject playerSwap;

    public float sprintSpeed = 9f;

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


    Vector3 direction = new Vector3(0f, 0f, 0f);

    float SlerpTime=0;

    public TongueTrap tongueCode;

    public FoulFangs fangsCode;

    //Last Direction
    int LastInputDirection; //A=4, D=6, W=8,S=2

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontalMove = horizontal * speed;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Animation", 1); //Walk
        }
        else
        {
           anim.SetInteger("Animation", 0); //Idle
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector3(8, playerRB.velocity.y, 0);

            LastInputDirection = 4;

            playerRB.transform.rotation = Quaternion.Euler(0, 90, 0);

            
            SlerpTime = SlerpTime + Time.deltaTime;

            if (SlerpTime>1)
            {
                SlerpTime = 1;
            }else if (SlerpTime < 0)
            {
                SlerpTime = 0;
            }

            playerRB.transform.rotation = Quaternion.Slerp(playerRB.transform.rotation, Quaternion.LookRotation(new Vector3(1, 0, 0)), Time.deltaTime * 10);
            

        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector3(-8, playerRB.velocity.y, 0);

            LastInputDirection = 6;

            playerRB.transform.rotation = Quaternion.Euler(0, 270, 0);
            
            SlerpTime = SlerpTime - Time.deltaTime;

            if (SlerpTime <- 1)
            {
                SlerpTime = -1;
            }
            else if (SlerpTime > 0)
            {
                SlerpTime = 0;
            }

            playerRB.transform.rotation = Quaternion.Slerp(playerRB.transform.rotation, Quaternion.LookRotation(new Vector3(-1, 0, 0)), Time.deltaTime*10);
            
        }
        else
        {
            
            playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
            if (SlerpTime <0 && SlerpTime>-1)
            {
                SlerpTime = SlerpTime - Time.deltaTime;
                playerRB.transform.rotation = Quaternion.Slerp(playerRB.transform.rotation, Quaternion.LookRotation(new Vector3(-1, 0, 0)), Time.deltaTime * 10);
            }
            else if (SlerpTime > 0 && SlerpTime < 1)
            {
                SlerpTime = SlerpTime + Time.deltaTime;
                playerRB.transform.rotation = Quaternion.Slerp(playerRB.transform.rotation, Quaternion.LookRotation(new Vector3(1, 0, 0)), Time.deltaTime * 10);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            LastInputDirection = 8;
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, -8);
            playerRB.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            LastInputDirection = 2;
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, 8);
            playerRB.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        velocity.y += gravity * Time.deltaTime;

        tongueCode.waitTimer = tongueCode.waitTimer - Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && anim.GetBool("onAir") == true)
        {
            anim.SetTrigger("landTrigger");
            anim.SetBool("onAir", false); 
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
    }

    public void Slam()
    {
        transform.GetComponent<Rigidbody>().AddForce(0, -20, 0, ForceMode.Impulse);
        hs.damage = 100;
        Debug.Log(hs.damage);
    }
}
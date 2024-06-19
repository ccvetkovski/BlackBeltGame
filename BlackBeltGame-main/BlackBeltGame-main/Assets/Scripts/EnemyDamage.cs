using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class EnemyDamage : MonoBehaviour
{
    [Header("Variables")]
    public Transform gameObj;
    public float damageTime = 100;
    public float waitTimer = 0;
    public GameObject enemy;
    public float damage;
    public float playerDamage;
    public BoxCollider collider;
    public AudioSource hit;
    [SerializeField] ParticleSystem hitParticle = null;

    public EnemyAbility ea;
    public HealthSystem hs;

    public bool isPlayerDamaged = false;

    public Animator cameraAnim;

    public float healRate;

    void Start()
    {
        gameObject.SetActive(true);
        cameraAnim.enabled = false;
        hit.enabled = false;
    }
        
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Prey")
        {
            enemy = other.gameObject;
            ea = enemy.GetComponent<EnemyAbility>();
            waitTimer = 100;
        }

        if (other.gameObject.tag == "Player")
        {
            enemy = other.gameObject;
            hs = enemy.GetComponent<HealthSystem>();
            isPlayerDamaged = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerDamaged = false;
            cameraAnim.enabled = false;
            enemy = null;
            hit.enabled = false;
        }
    }

    void Update()
    {
        gameObject.SetActive(true);

        collider.enabled = true;

        if (waitTimer > 0)
        {
            waitTimer = waitTimer - Time.deltaTime;
            ea.healthPoints -= damage;
        }

        if (isPlayerDamaged == true)
        {
            hs.playerHealth -= playerDamage; 
            cameraAnim.enabled = true;
            hit.enabled = true;
            hitParticle.Play();
        }

        if (waitTimer < 0 && enemy == null)
        {
            gameObject.SetActive(true);
            ea.healthPoints -= 0;
            waitTimer = 0;
        }

        if (waitTimer < 0)
        {
            enemy = null;
            ea.healthPoints -= 0;
        }

        if (isPlayerDamaged == false && enemy == null)
        {
            gameObject.SetActive(true);
            hs.playerHealth -= 0;
            cameraAnim.enabled = false;
        }

        if (isPlayerDamaged == false)
        {
            enemy = null;
            gameObject.SetActive(true);
            hs.playerHealth -= 0; 
            hit.enabled = false;
            hitParticle.Stop();
        }

        if(isPlayerDamaged == false)
        {
            hs.playerHealth += healRate;
        }

        if(hs.playerHealth > 100)
        {
            hs.playerHealth = 100;
        }

        if(hs.playerHealth < 0)
        {
            hs.playerHealth = 0;
        }
    }
}

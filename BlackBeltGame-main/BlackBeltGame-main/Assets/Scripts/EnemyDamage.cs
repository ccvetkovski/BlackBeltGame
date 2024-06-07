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

    public EnemyAbility ea;
    public HealthSystem hs;

    void Start()
    {
        gameObject.SetActive(true);
    }
        
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject.name);
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
            waitTimer = 100;
            hs.wasHit = true;
            hs.canBeHit = false;
            hs.curVigIntensity = hs.vignette.intensity.value;
            hs.vignetteMove = true;
        }
    }

    void Update()
    {
        gameObject.SetActive(true);

        Debug.Log(hs.playerHealth);

        gameObj.GetComponent<BoxCollider>().enabled = true;

        if (waitTimer > 0)
        {
            //Debug.Log(ea.healthPoints);
            waitTimer = waitTimer - Time.deltaTime;
            ea.healthPoints -= damage;
            hs.playerHealth -= damage;
        }

        if (waitTimer < 0 && enemy == null)
        {
            gameObject.SetActive(true);
            ea.healthPoints -= 0;
            hs.playerHealth -= 0;
            waitTimer = 0;
        }

        if (waitTimer < 0)
        {
            enemy = null;
            gameObject.SetActive(true);
            ea.healthPoints -= 0;
            hs.playerHealth -= 0;
        }
    }
}

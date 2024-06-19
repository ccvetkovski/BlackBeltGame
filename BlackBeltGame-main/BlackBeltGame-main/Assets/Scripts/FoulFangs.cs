using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class FoulFangs : MonoBehaviour
{
    [Header("Variables")]
    public Transform fangs;
    public float abilityTime = 3;
    public float waitTimer = 0;
    public GameObject enemy;

    public HealthSystem hs; 
    public EnemyAbility ea; 

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxEnemy") && enemy == null)
        {
            enemy = other.gameObject;
            ea = enemy.GetComponent<EnemyAbility>();
            waitTimer = 3;
        }
    }

    void Update()
    {

        if (waitTimer > 0)
        {
            waitTimer = waitTimer - Time.deltaTime;
            ea.healthPoints -= 0.7f;
        }

        if (waitTimer < 0 && enemy == null)
        {
            gameObject.SetActive(false);
        }

        if (waitTimer < 0)
        {
            enemy = null;
            gameObject.SetActive(false);
        }
    }
}

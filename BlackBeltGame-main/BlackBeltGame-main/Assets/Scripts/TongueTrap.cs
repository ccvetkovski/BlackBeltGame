using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class TongueTrap : MonoBehaviour
{
    [Header("Variables")]
    public Transform tongue;
    public float abilityTime = 3;
    public float waitTimer = 0;
    public GameObject enemy;

    public HealthSystem hs;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxEnemy") && enemy == null)
        {
            enemy = other.gameObject; 
            waitTimer = 4;
            hs.damage++;
        }
    }

    void Update()
    {
        if (waitTimer > 0)
        {
            enemy.GetComponent<BoxCollider>().enabled = false;
            enemy.transform.position = tongue.gameObject.transform.position;
            waitTimer = waitTimer - Time.deltaTime;
        }

        if (waitTimer < 0 && enemy == null)
        {
            gameObject.SetActive(false);
        }

        if (waitTimer < 0)
        {
            enemy.GetComponent<BoxCollider>().enabled = true;
            enemy = null;
            gameObject.SetActive(false);
        }
    }
}

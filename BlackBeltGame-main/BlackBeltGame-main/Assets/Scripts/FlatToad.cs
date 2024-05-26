using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlatToad : MonoBehaviour
{
    public Rigidbody rb;
    bool isAttack;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        enemy.transform.localPosition = new Vector3(-21.2f, 7.42f, 0.19f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.useGravity = false;
        if(isAttack == true)
        {
            rb.useGravity = true;
            enemy.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    public void Attack()
    {
        rb.useGravity = true;
        isAttack = true;
        rb.AddForce(0, -5, 0, ForceMode.Impulse);
        enemy.GetComponent<NavMeshAgent>().enabled = false;
    }
}

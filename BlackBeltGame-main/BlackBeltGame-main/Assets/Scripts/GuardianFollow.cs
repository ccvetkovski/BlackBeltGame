using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianFollow : MonoBehaviour
{
    [SerializeField] private GameObject deer;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] Vector3 followOffset;
    [SerializeField] public float followSharpness = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        followOffset = transform.position - deer.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void LateUpdate () 
    {
        // Apply that offset to get a target position.
        Vector3 targetPosition = deer.transform.position + followOffset;

        // Smooth follow.    
        transform.position += (targetPosition - transform.position) * followSharpness;


        //Follow
        transform.position = Vector3.MoveTowards(transform.position, deer.transform.position, speed * Time.deltaTime);
        transform.forward = deer.transform.position - transform.position;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GuardianFollow : MonoBehaviour
//{
//    public GameObject target;
//    public Rigidbody rb;
//    private Vector3 dir;
//    public int moveSpeed = 5;

//    public void Follow()
//    {
//        dir = (target.transform.position - this.transform.position).normalized;
//        rb.MovePosition(this.gameObject.transform.position + dir * moveSpeed * Time.deltaTime);
//    }

//    public void FixedUpdate()
//    {
//        if (this.transform.position != target.transform.position)
//        {
//            Follow();
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{   
    public Rigidbody rb;
    public int upwardsForce;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rb.AddForce(0, upwardsForce, 0, ForceMode.Impulse);
        }
    }
}

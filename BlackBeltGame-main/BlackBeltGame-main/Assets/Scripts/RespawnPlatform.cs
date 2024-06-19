using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    public GameObject respawnPoint;
    public BoxCollider obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj.enabled = true;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
    
}

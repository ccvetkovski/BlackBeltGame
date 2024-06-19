using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    public BoxCollider collider;
    public MeshRenderer renderer;
    public float waitTimer = 0;
    public float disabledTime;
    
    private void OnTriggerEnter(Collider other) {
        waitTimer = 1.5f;
    }

    void Update()
    {
        if (waitTimer > 0)
        {   
            collider.enabled = true;
            renderer.enabled = true;
            disabledTime = (int)0;
            waitTimer = waitTimer - Time.deltaTime;
        }

        if (waitTimer < 0)
        {
            disabledTime = 1.5f;
        }

        if (disabledTime > 0)
        {   
            collider.enabled = false;
            renderer.enabled = false;
            waitTimer = (int)0;
            disabledTime = disabledTime - Time.deltaTime;
        }

        if (disabledTime < 0)
        {
            waitTimer = 1.5f;
        }
    }
}

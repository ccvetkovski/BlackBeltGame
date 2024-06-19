using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public BoxCollider collider;
    public MeshRenderer renderer;
    public float waitTimer = 0;
    public float disabledTime;
    
    void Start()
    {
        waitTimer = 3f;
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
            disabledTime = 2f;
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
            waitTimer = 2f;
        }
    }
}

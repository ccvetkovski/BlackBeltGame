using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class BlitzBurst : MonoBehaviour
{
    [Header("Variables")]
    public float abilityTime = 3;
    public float waitTimer = 0;
    public DeerMovement moveCode;

    void Update()
    {
        if (waitTimer > 0)
        {
            moveCode.speed = 15;
            waitTimer = waitTimer - Time.deltaTime;
        }

        if (waitTimer < 0)
        {
            moveCode.speed = 9;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PhantomProwl : MonoBehaviour
{
    [Header("Variables")]
    public GameObject opaqueDeer;
    public GameObject transparentDeer;
    public float abilityTime = 3;
    public float waitTimer = 0;

    void Update()
    {
        if (waitTimer > 0)
        {
            opaqueDeer.SetActive(false);
            transparentDeer.SetActive(true);
            waitTimer = waitTimer - Time.deltaTime;
        }

        if (waitTimer < 0)
        {
            opaqueDeer.SetActive(true);
            transparentDeer.SetActive(false);
        }
    }
}

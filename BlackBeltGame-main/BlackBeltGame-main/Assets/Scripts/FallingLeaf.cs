using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    [Header("Variables")]
    public float stayUpTime = 3;
    public float stayDownTime = 3;
    public float waitTimerUp = 0;
    public float waitTimerDown = 0;

    void Start()
    {
        waitTimerUp = 3;
    }

    void Update()
    {
        if (waitTimerUp > 0)
        {
            gameObject.SetActive(true);
            waitTimerUp = waitTimerUp - Time.deltaTime;
            waitTimerDown = null;
        }

        if (waitTimerUp < 0)
        {
            waitTimerDown = 3;
        }

        if (waitTimerDown > 0)
        {
            gameObject.SetActive(false);
            waitTimerDown = waitTimerDown - Time.deltaTime;
            waitTimerUp = null;
        }

        if (waitTimerDown < 0)
        {
            waitTimerUp = 3;
        }
    }
}

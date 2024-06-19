using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeed;
    public Transform platform;

    // Update is called once per frame
    void Update()
    {
        platform.position = platform.position + new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}

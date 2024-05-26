using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public Transform target;
    public GameObject enemy;

    public float dropDistance;

    private float defaultHeight;
    private float targetHeight;

    public float dropSpeed=0.1f;

    private float fraction = 1; // 1= defaulHeight,  0 = targetHeight
    // Start is called before the first frame update
    void Start()
    {
        defaultHeight = enemy.transform.position.y;
        targetHeight = target.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= dropDistance;
            if (inRange)
            {
                if (fraction > 0)
                {
                    fraction = fraction - (Time.deltaTime * dropSpeed);
                }
                enemy.transform.localPosition = new Vector3(enemy.transform.localPosition.x, Mathf.Lerp(targetHeight, defaultHeight, fraction), enemy.transform.localPosition.z);
            }
            else
            {

            }
        }
    }
}

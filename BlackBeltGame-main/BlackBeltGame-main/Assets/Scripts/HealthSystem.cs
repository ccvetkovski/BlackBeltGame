using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class HealthSystem : MonoBehaviour
{

    public float playerHealth;
    public float damage = 5;
    public Animator camAnim;
    public EnemyDamage enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);  
            camAnim.enabled = false;
            enemyDamage.isPlayerDamaged = true;
        } 
    }
}

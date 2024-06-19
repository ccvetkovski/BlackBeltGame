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
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        loseScreen.SetActive(false);
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            loseScreen.SetActive(true);
            camAnim.enabled = false;
            Destroy(gameObject);
        } 
    }
}

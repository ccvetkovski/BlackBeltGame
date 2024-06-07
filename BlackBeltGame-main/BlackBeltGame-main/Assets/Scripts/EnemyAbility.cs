using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    public AbilityManager.Ability[] ability;
    public GameObject player;
    public float healthPoints;

    private void AddAbility()
    {
        for (int i = 0; i < ability.Length; i++)
        {
            player.GetComponent<AbilityManager>().AddAbility(ability[i]);
        }
    }

    void Start()
    {
        healthPoints = 100;
    }

    void Die()
    {
        if (healthPoints <= 0)
        {
            Debug.Log("The enemy has died.");
            AddAbility();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Die();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            healthPoints -= 25;
            Debug.Log("Health points has been lowered.");
        }
    }
}

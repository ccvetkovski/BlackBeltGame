using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    public AbilityManager.Ability[] ability;
    public GameObject player;
    public float healthPoints;
    public GameObject winScreen;

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
        winScreen.SetActive(false);
    }

    void Die() 
    {
        if (healthPoints <= 0)
        {
            Debug.Log("The enemy has died.");
            AddAbility();
            Destroy(gameObject);
        }

        if (healthPoints <= 0 && gameObject.name == "Croc")
        {
            winScreen.SetActive(true);
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
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    public AbilityManager.Ability ability;
    private GameObject player;

    private void AddAbility()
    {
        player.GetComponent<AbilityManager>().AddAbility(ability);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}

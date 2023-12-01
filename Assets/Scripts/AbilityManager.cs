using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private List<Ability> abilities = new List<Ability>();

    public enum Ability
    {
        Ability1,
        Ability2,
        Ability3,
        Ability4
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddAbility(Ability a)
    {
        abilities.Add(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public GameObject cardViewer;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;

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
        if (a == Ability.Ability1)
        {
            GameObject newCard = Instantiate(card1);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.Ability2)
        {
            GameObject newCard = Instantiate(card2);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.Ability3)
        {
            GameObject newCard = Instantiate(card3);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.Ability4)
        {
            GameObject newCard = Instantiate(card4);
            newCard.transform.parent = cardViewer.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveAbility(Ability b)
    {
        for (int i = 0; i< abilities.Count; i++) 
        {
            if (abilities[i] == b)
            {
                abilities.Remove(abilities[i]);
            }
        }
    }
}

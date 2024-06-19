using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public GameObject cardViewer;

    public GameObject player;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;

    public enum Ability
    {
        PressurePolliwog, 
        TongueTrap,
        FoulFangs,
        LiquidLungs,
        PhantomProwl,
        BlitzBurst
    }

    // Start is called before the first frame update
    void Update()
    {
        RemoveAbility();
    }

    public void AddAbility(Ability a)
    {
        abilities.Add(a);
        if (a == Ability.PressurePolliwog)
        {
            GameObject newCard = Instantiate(card1);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.TongueTrap)
        {
            GameObject newCard = Instantiate(card2);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.FoulFangs)
        {
            GameObject newCard = Instantiate(card3);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.BlitzBurst)
        {
            GameObject newCard = Instantiate(card4);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.PhantomProwl)
        {
            GameObject newCard = Instantiate(card5);
            newCard.transform.parent = cardViewer.transform;
        }
    }
    public void RemoveAbility()
    {
        for (int i = 0; i < cardViewer.transform.childCount; i++)
        {
            if (cardViewer.transform.GetChild(i).GetComponent<CardInFront>().isChosen)
            {
                AbilityManager.Ability ability = cardViewer.transform.GetChild(i).GetComponent<CardInFront>().ability;

                //Apply your ability here
                player.GetComponent<DeerMovement>().UseAbility(ability);

                //Remove ability or card from the scene
                abilities.Remove(ability);
                Destroy(cardViewer.transform.GetChild(i).gameObject);
            }
        }

    }
}
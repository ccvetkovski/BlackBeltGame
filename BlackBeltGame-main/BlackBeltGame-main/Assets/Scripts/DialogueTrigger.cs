using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueBox;
    public Dialogue dialogue;
    public int triggeredAmount;

    public void TriggerDialogue()
    {
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && triggeredAmount == 0)
        {
            TriggerDialogue();
            triggeredAmount++;
        }

        if(other.gameObject.CompareTag("Player") && triggeredAmount == 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(triggeredAmount > 1)
        {
            Destroy(gameObject);
        }
    }
}

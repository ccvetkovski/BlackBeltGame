using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueBox;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other) {
        TriggerDialogue();
    }

}

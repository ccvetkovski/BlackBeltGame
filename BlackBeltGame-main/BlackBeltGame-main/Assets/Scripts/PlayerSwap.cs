using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public CinemachineVirtualCamera cam;
    public GameObject Deer;
    public GameObject CardManager;

    void Start()
    {
        if(character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(whichCharacter == 0)
            {
                switchCharacter();
            }
            else 
            {
                whichCharacter -= 1;
            }
            Swap();
        }
    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i] != character)
            {
                
            }

            if(character == possibleCharacters[1])
            {
                Deer.GetComponent<Rigidbody>().isKinematic = true;
                CardManager.SetActive(true);
            }
            else
            {
                Deer.GetComponent<Rigidbody>().isKinematic = false;
                CardManager.SetActive(false);
            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }

     public void switchCharacter()
    {
        Debug.Log("swap is running");
        whichCharacter = (whichCharacter == 1) ? 0 : 1;
        character = possibleCharacters[whichCharacter];
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {

            }

            if (character == possibleCharacters[1])
            {
                Deer.GetComponent<Rigidbody>().isKinematic = true;
                CardManager.SetActive(true);
            }
            else
            {
                Deer.GetComponent<Rigidbody>().isKinematic = false;
                CardManager.SetActive(false);
            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }
}

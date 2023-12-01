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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else 
            {
                whichCharacter -= 1;
            }
            Swap();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(whichCharacter == possibleCharacters.Count - 1)
            {
                whichCharacter = 0;
            }
            else 
            {
                whichCharacter += 1;
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
                Deer.GetComponent<DeerMovement>().enabled = false;
                CardManager.SetActive(true);
            }
            else
            {
                Deer.GetComponent<Rigidbody>().isKinematic = false;
                Deer.GetComponent<DeerMovement>().enabled = true;
                CardManager.SetActive(false);
            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }
}

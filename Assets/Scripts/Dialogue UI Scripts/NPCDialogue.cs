using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public PlayerUI playerUI; // Reference to the PlayerUI script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartConversation()
    {
        playerUI.ShowDialogue("Hello, traveler!");

        string[] choices = { "Hi!", "Who are you?", "Goodbye." };
        playerUI.ShowChoices(choices, OnPlayerChoice);
    }

    void OnPlayerChoice(int index)
    {
        Debug.Log("Player chose option: " + index);

        if (index == 0)
        {
            playerUI.ShowDialogue("Nice to meet you!");
        }
        else if (index == 1)
        {
            playerUI.ShowDialogue("I am the village elder.");
        }
        else if (index == 2)
        {
            playerUI.ShowDialogue("Farewell!");
        }
    }
}

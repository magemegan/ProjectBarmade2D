using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public DialogueData dialogueData; // Reference to the DialogueData scriptable object
    public PlayerUI playerUI; // Reference to the PlayerUI script
    public string npcName; // Name of the NPC
    private bool playerInRange = false;
    private int currentNode = 0; // Current node in the dialogue tree

    void Update()
    {
        if (playerInRange)
        {
            Debug.Log("Player is in range of NPC");
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player pressed E while in range");
            StartConversation();
        }
        //if (playerInRange && Input.GetKeyDown(KeyCode.E))
        //{
        //    StartConversation();
        //}
    }

    public void StartConversation()
    {
        currentNode = 0;
        ShowCurrentNode();
    }

    void ShowCurrentNode()
    {

        if (currentNode < dialogueData.dialogueNodes.Length)
        {
            var node = dialogueData.dialogueNodes[currentNode];

            playerUI.ShowDialogue(dialogueData.npcName, node.npcText);
            playerUI.ShowChoices(node.playerChoices, OnPlayerChoice);
            Debug.Log("ShowCurrentNode called");
        }
        else
        {
            EndConversation();
        }
    }

    void OnPlayerChoice(int index)
    {
        var node = dialogueData.dialogueNodes[currentNode];

        if (node.nextNodeLeads != null && index < node.nextNodeLeads.Length)
        {
            int nextNode = node.nextNodeLeads[index];
            if (nextNode >= 0 && nextNode < dialogueData.dialogueNodes.Length)
            {
                currentNode = nextNode;
                ShowCurrentNode();
            }
            else
            {
                EndConversation();
            }
        }
        else
        {
            EndConversation();
        }
    }

    void EndConversation()
    {
        playerUI.HideDialogue();
        Debug.Log($"{gameObject.name}: Conversation ended");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

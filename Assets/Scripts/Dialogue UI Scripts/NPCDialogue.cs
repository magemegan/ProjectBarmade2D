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
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();
        }
    }

    public void StartConversation()
    {
        playerUI.HidePressE();
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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            playerUI.ShowPressE();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            playerUI.HidePressE();
        }
    }
}

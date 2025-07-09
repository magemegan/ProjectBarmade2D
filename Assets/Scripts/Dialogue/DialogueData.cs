using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] 
public class DialogueNode
{
    [TextArea] // TODO: It should be clear in script what this is doing
    public string npcText;
    public string[] playerChoices;
    public int[] nextNodeLeads;//branch paths // TODO: This variable name should be made more clear
}
//Let the user create this ScriptableObject as an asset in the editor
[CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/DialogueData")] // TODO: Why are we allowing users to create dialogue data? 
public class DialogueData : ScriptableObject
{
    public string npcName;//Name of the NPC 
    //This is the array of DialogueNode objects that will be used to create the dialogue tree
    public DialogueNode[] dialogueNodes;
}

/* TODO: 
 * public variables should be seriazized and have getter functions
*/
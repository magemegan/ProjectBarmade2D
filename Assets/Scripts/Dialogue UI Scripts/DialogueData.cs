using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] 
public class DialogueNode
{
    [TextArea]
    public string npcText;
    public string[] playerChoices;
    public int[] nextNodeLeads;//branch paths
}
//Let the user create this ScriptableObject as an asset in the editor
[CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string npcName;//Name of the NPC
    //This is the array of DialogueNode objects that will be used to create the dialogue tree
    public DialogueNode[] dialogueNodes;
}

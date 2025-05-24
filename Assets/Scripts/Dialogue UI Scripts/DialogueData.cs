using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField] public class DialogueNode
{
    //Text Area
    public string npcText;
    public string[] playerChoices;
}
//Let the user create this ScriptableObject as an asset in the editor
[CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    //This is the array of DialogueNode objects that will be used to create the dialogue tree
    public DialogueNode[] dialoguestuff;
}

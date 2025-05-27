using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject accessStationText;
    public GameObject DrinkStationUI;
    public GameObject DialogueUI;
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;
    public GameObject choicesPanel;
    public Button[] choiceButtons;

    private bool CanOpenDialogue = false;
    private bool CanAccessDrinkStation = false;
    private bool DrinkStationOn = false;

    //It’s a placeholder for “what to do when a player clicks a choice button."
    private System.Action<int> currentChoiceCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Access Drink Mixing Station
        if(Input.GetKeyDown(KeyCode.E) && CanAccessDrinkStation && !DrinkStationOn) {
            DrinkStationUI.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().movementEnabled = false;
            DrinkStationOn = true;
            accessStationText.SetActive(false);
        } else if(Input.GetKeyDown(KeyCode.E) && CanAccessDrinkStation && DrinkStationOn){
            DrinkStationUI.SetActive(false);
            gameObject.GetComponent<PlayerMovement>().movementEnabled = true;
            DrinkStationOn = false;
            accessStationText.SetActive(true);
        }

        //Open NPC Dialogue
        //if (Input.GetKeyDown(KeyCode.E) && CanOpenDialogue)
        //{
        //    DialogueUI.SetActive(true);
        //    gameObject.GetComponent<PlayerMovement>().movementEnabled = false;
        //    CanOpenDialogue = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.E) && !CanOpenDialogue)
        //{
        //    DialogueUI.SetActive(false);
        //    gameObject.GetComponent<PlayerMovement>().movementEnabled = true;
        //}
    }

    //This function is called to show the dialogue text without choices
    public void ShowDialogue(string npcName, string message)
    {
        DialogueUI.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().movementEnabled = false;
        npcNameText.text = npcName;
        dialogueText.text = message;
        choicesPanel.SetActive(false);
    }

    public void HideDialogue()
    {
        DialogueUI.SetActive(false);  // Hides the whole dialogue panel
        choicesPanel.SetActive(false);   // Hides the choices if they’re visible
        gameObject.GetComponent<PlayerMovement>().movementEnabled = true; // Re-enable player movement
    }

    //This function is called when the player chooses a dialogue option with choices
    public void ShowChoices(string[] choices, System.Action<int> onChoiceSelected)
    {
        choicesPanel.SetActive(true);
        currentChoiceCallback = onChoiceSelected;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i];
                int index = i;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    //This function is called when the player selects a choice from the dialogue options
    private void OnChoiceSelected(int index)
    {
        choicesPanel.SetActive(false);
        currentChoiceCallback?.Invoke(index);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("DrinkStation")) {
            accessStationText.SetActive(true);
            CanAccessDrinkStation = true;
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            CanOpenDialogue = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("DrinkStation")) {
            accessStationText.SetActive(false);
            CanAccessDrinkStation = false;
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            CanOpenDialogue = false;
        }
    }
}

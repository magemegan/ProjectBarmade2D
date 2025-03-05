using UnityEngine;
using UnityEngine.UI;

public class DraftBeerMachine : MonoBehaviour
{
    public GameObject beerSelectionUI; // Assign the UI Panel in the Inspector
    public Text logText; // Assign a Text UI element to display selected beer

    private bool isPlayerNear = false;
    private string[] beers = { "Lager", "IPA", "Stout", "Pilsner", "Porter", "Wheat Beer", "Amber Ale", "Pale Ale" };

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowBeerMenu();
        }
    }

    public void SelectBeer(int beerIndex)
    {
        if (beerIndex >= 0 && beerIndex < beers.Length)
        {
            Debug.Log("Player selected: " + beers[beerIndex]);
            if (logText != null)
                logText.text = "Selected Beer: " + beers[beerIndex];
            beerSelectionUI.SetActive(false); // Hide UI after selection
        }
    }

    private void ShowBeerMenu()
    {
        beerSelectionUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            beerSelectionUI.SetActive(false);
        }
    }
}
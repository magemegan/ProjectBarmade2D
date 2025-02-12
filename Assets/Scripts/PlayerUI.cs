using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject accessStationText;
    public GameObject DrinkStationUI;
    private bool CanAccessDrinkStation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && CanAccessDrinkStation) {
            DrinkStationUI.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("DrinkStation")) {
            accessStationText.SetActive(true);
            CanAccessDrinkStation = true;
        }

        
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("DrinkStation")) {
            accessStationText.SetActive(false);
            CanAccessDrinkStation = false;
        }
    }
}

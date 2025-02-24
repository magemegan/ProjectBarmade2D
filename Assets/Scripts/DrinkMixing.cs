using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrinkMixing : MonoBehaviour, IPointerClickHandler
{
    public enum DrinkType { Alcohol, Soda }
    public GameObject[] AlcoholBottles;
    public GameObject[] SodaBottles;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("UI Image clicked: " + gameObject.name);
    }
}

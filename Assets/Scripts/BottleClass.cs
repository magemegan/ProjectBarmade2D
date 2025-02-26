using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BottleClass : MonoBehaviour, IPointerClickHandler
{
    public enum DrinkType { Soda, Alcohol }
    public DrinkType drinkType;

    public enum SodaType {Cola, Sprite, Gingerale }
    public enum AlcoholType {Scotch, Rum, Gin, Moonshine, Vodka, Whiskey }

    [HideInInspector] public SodaType sodaType;
    [HideInInspector] public AlcoholType alcoholType;

    private DrinkType previousDrinkType = (DrinkType)(-1);
    public float alcoholVolume = 0f;


    private void OnValidate()
    {
        if (drinkType != previousDrinkType)
        {
            //Reset other enum, if alcohol or soda were selected
            if (drinkType == DrinkType.Soda)
            {
                alcoholType = (AlcoholType)0;
            }
            else
            {
                sodaType = (SodaType)0;
            }

            previousDrinkType = drinkType;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sodaType);
        Debug.Log(alcoholType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
    }
}

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

    private bool holdingDrink;

    Camera camera;

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
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(holdingDrink) {

            Vector3 cameraPos = camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        holdingDrink = true;
    }
}

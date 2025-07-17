using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class DrinkComponent
{
    [SerializeField] Ingredient ingredient;
    [SerializeField] int milliliters = 0; // Amount of this ingredient in the drink
}

[CreateAssetMenu(fileName = "NewDrinkRecipe", menuName = "Bar/DrinkRecipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] string drinkName;
    [SerializeField] DrinkComponent baseSpirit;
    [SerializeField] DrinkComponent[] mixers; // TODO: Is 2 the actual mixer cap? 
    [SerializeField] Ingredient[] garnishes;
    [SerializeField] bool hasIce;
    [SerializeField] bool isBlended;
    [SerializeField] float price;
}

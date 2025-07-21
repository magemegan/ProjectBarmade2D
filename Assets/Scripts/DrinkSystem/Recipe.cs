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
    [Header("Drink Info")]
    [SerializeField] string drinkName;
    [SerializeField] DrinkComponent[] spirits;
    [SerializeField] DrinkComponent[] mixers;
    [SerializeField] Ingredient[] garnishes;
    [SerializeField] GLASS glass;
    [SerializeField] bool hasIce;
    [SerializeField] bool isBlended;
    [Header("Sale Info")]
    [SerializeField] float price;
    [SerializeField] bool isUnlocked;
}

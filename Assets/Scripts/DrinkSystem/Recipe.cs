using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDrinkRecipe", menuName = "Bar/DrinkRecipe")]
public class Recipe : ScriptableObject
{
    [Header("Drink Info")]
    [SerializeField] string drinkName;
    [SerializeField] DrinkComponent[] spirits;
    [SerializeField] DrinkComponent[] mixers;
    [SerializeField] Ingredient[] garnishes;
    [SerializeField] Glass glass;
    [SerializeField] bool hasIce;
    [SerializeField] bool isBlended;
    [Header("Sale Info")]
    [SerializeField] float price;
    [SerializeField] bool isUnlocked;

    public bool getUnlocked()
    { return isUnlocked; }

    public Recipe() { }
    public Recipe(string name, DrinkComponent[] spirits, DrinkComponent[] mixers, 
        Ingredient[] garnishes, Glass glass, bool hasIce, bool isBlended)
    {
        drinkName = name;
        this.spirits = spirits;
        this.mixers = mixers;  
        this.garnishes = garnishes;
        this.glass = glass;
        this.hasIce = hasIce;
        this.isBlended = isBlended;
    }

    public float GetAmountEarned(float multiplier)
    {
        return price * multiplier;
    }
}

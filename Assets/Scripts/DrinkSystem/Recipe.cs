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
    public static Recipe Create(string name, DrinkComponent[] spirits, DrinkComponent[] mixers, 
        Ingredient[] garnishes, Glass glass, bool hasIce, bool isBlended)
    {
        Recipe recipe = new Recipe();
        recipe.drinkName = name;
        recipe.spirits = spirits;
        recipe.mixers = mixers;  
        recipe.garnishes = garnishes;
        recipe.glass = glass;
        recipe.hasIce = hasIce;
        recipe.isBlended = isBlended;
        return recipe;
    }

    public float GetAmountEarned(float multiplier)
    {
        return price * multiplier;
    }

    public DrinkComponent[] GetSpirits() { return spirits; }
    public DrinkComponent[] GetMixers() {  return mixers; }
    public Ingredient[] GetGarnishes() { return garnishes; }
    public Glass GetGlass() {  return glass; }
    public bool GetIce() { return hasIce; }
}

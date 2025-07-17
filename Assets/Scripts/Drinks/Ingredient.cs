using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE
{
    SPIRIT,
    MIXER,
    GARNISH
}

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Bar/Ingredient")]

[System.Serializable]
public class Ingredient : ScriptableObject
{
    [SerializeField] string ingredientName;
    [SerializeField] TYPE type;
    [Range(0f, 1f)]
    [SerializeField] float alcoholPercentage = 0f;
    [SerializeField] int milliliters = 0; // to be used when adding ingredient to drink
}
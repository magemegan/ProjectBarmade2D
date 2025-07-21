using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum INGREDIENTTYPE // TODO: Find a different name :( 
{
    SPIRIT,
    MIXER,
    GARNISH
}

public enum GLASS
{
    MARTINI,
    SHOT,
    ROCKS,
    MARGARITA,
    CHAMPANGE,
    WINE,
    BEER,
    COCKTAIL,
    HIGHBALL
}

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Bar/Ingredient")]

[System.Serializable]
public class Ingredient : ScriptableObject
{
    [SerializeField] string ingredientName;
    [SerializeField] INGREDIENTTYPE type;
    [Range(0f, 1f)] [SerializeField] float alcoholPercentage = 0f;
}
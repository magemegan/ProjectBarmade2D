using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class DrinkController : MonoBehaviour
{
    public GameObject drink;
    private ItemHolder itemHolder;

    // Drink creation
    private List<Ingredient> ingredients = new List<Ingredient>();
    private float percentage = 0f; // max: 1
    private bool containsIce = false;

    void Start()
    {
        itemHolder = GameObject.FindWithTag("Player").GetComponentInChildren<ItemHolder>();
        if (percentage > 1)
        {
            Debug.Log(name + " alcohol percentage exceeds 100%. Scripts may not work as intended.");
        }
    }

    public void GiveDrink()
    {
        Debug.Log("give drink");
        itemHolder.GiveObject(gameObject);
    }
    public void SpawnDrink()
    {
        GameObject clone = GameObject.Instantiate(drink);
        itemHolder.GiveObject(clone);
        clone.SetActive(true);
    }

    public float GetAlcoholPercentage()
    {
        return percentage;
    }

    // TODO: Add a method to add ingredients to the drink
}

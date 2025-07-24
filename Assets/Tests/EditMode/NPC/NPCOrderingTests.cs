using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NPCOrderingTests
{
    private NPCOrdering npcOrdering;
    private List<GameObject> testObjects;

    [SetUp]
    public void Setup()
    {
        testObjects = new List<GameObject>();
        GameObject testObject = new GameObject("TestNPCOrdering");
        testObjects.Add(testObject);
        npcOrdering = testObject.AddComponent<NPCOrdering>();
    }

    [TearDown]
    public void TearDown()
    {
        foreach (GameObject obj in testObjects)
        {
            if (obj != null)
            {
                Object.DestroyImmediate(obj);
            }
        }
        testObjects.Clear();
    }

    private List<Ingredient> CreateTestIngredients()
    {
        var ingredients = new List<Ingredient>();
        ingredients.Add(new Ingredient("Rum", IngredientType.SPIRIT, 0.4f));
        ingredients.Add(new Ingredient("Coke", IngredientType.MIXER, 0));
        ingredients.Add(new Ingredient("Lime", IngredientType.GARNISH, 0));
        return ingredients;
    }

    private Recipe CreateTestRecipe()
    {
        var ingredients = CreateTestIngredients();
        var rum = ingredients[0];
        var coke = ingredients[1];
        var lime = ingredients[2];

        DrinkComponent[] spirits = { new DrinkComponent(rum, 10) };
        DrinkComponent[] mixers = { new DrinkComponent(coke, 10) };
        Ingredient[] garnishes = { lime };

        return new Recipe("Vodka and Coke", spirits, mixers, garnishes,
            Glass.ROCKS, true, false);
    }

    private DrinkController CreateEmptyDrink()
    {
        GameObject drinkObject = new GameObject("TestDrink");
        testObjects.Add(drinkObject);
        return drinkObject.AddComponent<DrinkController>();
    }

    private DrinkController CreateDrinkFromRecipe(Recipe recipe)
    {
        DrinkController drink = CreateEmptyDrink();

        // Add spirits
        foreach (DrinkComponent spirit in recipe.GetSpirits())
        {
            drink.AddIngredient(spirit.GetIngredient(), spirit.GetMilliliters());
        }

        // Add mixers
        foreach (DrinkComponent mixer in recipe.GetMixers())
        {
            drink.AddIngredient(mixer.GetIngredient(), mixer.GetMilliliters());
        }

        // Add garnishes
        foreach (Ingredient garnish in recipe.GetGarnishes())
        {
            drink.AddGarnish(garnish);
        }

        // Add ice if recipe requires it
        if (recipe.GetIce())
        {
            drink.AddIce();
        }

        return drink;
    }

    private DrinkController CreatePartialDrink(Recipe recipe, bool skipSpirits = false,
        bool skipMixers = false, bool skipGarnishes = false, bool skipIce = false)
    {
        DrinkController drink = CreateEmptyDrink();

        if (!skipSpirits)
        {
            foreach (DrinkComponent spirit in recipe.GetSpirits())
            {
                drink.AddIngredient(spirit.GetIngredient(), spirit.GetMilliliters());
            }
        }

        if (!skipMixers)
        {
            foreach (DrinkComponent mixer in recipe.GetMixers())
            {
                drink.AddIngredient(mixer.GetIngredient(), mixer.GetMilliliters());
            }
        }

        if (!skipGarnishes)
        {
            foreach (Ingredient garnish in recipe.GetGarnishes())
            {
                drink.AddGarnish(garnish);
            }
        }

        if (!skipIce)
        {
            if (recipe.GetIce())
            {
                drink.AddIce();
            }
        }

        return drink;
    }

    [Test]
    public void GetRandomRecipe_ReturnsRecipe()
    {
        Recipe randomRecipe = npcOrdering.GetRandomRecipe();
        Assert.IsNotNull(randomRecipe);
    }

    [Test]
    public void GetRandomRecipe_RecipeIsUnlocked()
    {
        Recipe randomRecipe = npcOrdering.GetRandomRecipe();
        bool isUnlocked = randomRecipe.getUnlocked();
        Assert.True(isUnlocked);
    }

    [Test]
    public void GetRecipeAccuracy_EmptyDrink_ReturnsZero()
    {
        Recipe randomRecipe = npcOrdering.GetRandomRecipe();

        GameObject drinkObject = new GameObject("TestDrink");
        testObjects.Add(drinkObject);
        DrinkController emptyDrink = drinkObject.AddComponent<DrinkController>();

        float accuracy = npcOrdering.GetRecipeAccuracy(randomRecipe, emptyDrink);

        Assert.AreEqual(0, accuracy);
    }

    /*public void GetRecipeAccuracy_MissingOneIngredient_ReturnsDeduction()
    {
        Drink
    }*/
    // public void GetRecipeAccuracy_MissingAllIngredients_ReturnsFiftyPercent() {}
    // public void GetRecipeAccuracy_WrongIngredients_ReturnsDeduction() {}
    // public void GetRecipeAccuracy_WrongAmounts_ReturnsSeventyPercent() {}
    // public void GetRecipeAccuracy_MissingGarnish_ReturnsNinetyFivePercent() {}
    // public void GetRecipeAccuracy_IncorrectGarnish_ReturnsNinetyFivePercent() {}
    // public void GetRecipeAccuracy_MissingIce_ReturnsNinetyPercent() {}
    // public void GetRecipeAccuracy_EmptyRecipe_ReturnsOne() {}
    // public void GetRecipeAccuracy_PerfectDrink_ReturnsOne() {}

    // TODO: Implement tests for glass types
}
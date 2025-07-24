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
        ingredients.Add(Ingredient.Create("Rum", IngredientType.SPIRIT, 0.4f));
        ingredients.Add(Ingredient.Create("Coke", IngredientType.MIXER, 0));
        ingredients.Add(Ingredient.Create("Lime", IngredientType.GARNISH, 0));
        return ingredients;
    }

    private Recipe CreateTestRecipe()
    {
        var ingredients = CreateTestIngredients();
        var rum = ingredients[0];
        var coke = ingredients[1];
        var lime = ingredients[2];

        List<DrinkComponent> spirits = new List<DrinkComponent> { DrinkComponent.Create(rum, 10) };
        List<DrinkComponent> mixers = new List<DrinkComponent> { DrinkComponent.Create(coke, 10) };
        List<Ingredient> garnishes = new List<Ingredient> {lime };

        return Recipe.Create("Vodka and Coke", spirits, mixers, garnishes,
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
        DrinkController emptyDrink = CreateEmptyDrink();

        float accuracy = npcOrdering.GetRecipeAccuracy(randomRecipe, emptyDrink);

        Assert.AreEqual(0, accuracy);
    }

    [Test]
    public void GetRecipeAccuracy_MissingIngredient()
    {
        Recipe testRecipe = CreateTestRecipe();
        DrinkController drink = CreatePartialDrink(testRecipe, skipSpirits: true);

        float accuracy = npcOrdering.GetRecipeAccuracy(testRecipe, drink);

        Assert.AreEqual(0.6f, accuracy);
    }

    [Test]
    public void GetRecipeAccuracy_WrongIngredient() 
    {
        Recipe testRecipe = CreateTestRecipe();
        DrinkController drink = CreateDrinkFromRecipe(testRecipe);
        Ingredient vodka = Ingredient.Create("Vodka", IngredientType.SPIRIT, 0.4f);
        drink.AddIngredient(vodka);

        float accuracy = npcOrdering.GetRecipeAccuracy(testRecipe, drink);

        Assert.AreEqual(0.85f, accuracy);
    }
    // public void GetRecipeAccuracy_WrongAmounts_ReturnsSeventyPercent() {}
    // public void GetRecipeAccuracy_MissingGarnish_ReturnsNinetyFivePercent() {}
    // public void GetRecipeAccuracy_IncorrectGarnish_ReturnsNinetyFivePercent() {}
    // public void GetRecipeAccuracy_MissingIce_ReturnsNinetyPercent() {}
    // public void GetRecipeAccuracy_EmptyRecipe_ReturnsOne() {}
    // public void GetRecipeAccuracy_PerfectDrink_ReturnsOne() {}

    // TODO: Implement tests for glass types
    //TODO: Implement tests to check for duplicate ingredients
}

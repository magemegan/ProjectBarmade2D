using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DrinkControllerTests
{
    [Test]
    [TestCase(0f)]
    [TestCase(0.5f)]
    [TestCase(1f)]
    public void AddIngredient_AddsOneLiquid_UpdatesAlcoholPercentage(float percentage)
    {
        IngredientType[] types = { IngredientType.SPIRIT, IngredientType.MIXER };
        foreach (IngredientType type in types)
        {
            DrinkController controller = new DrinkController();
            Ingredient ingredient = new Ingredient();
            ingredient.SetType(type);
            ingredient.SetPercentage(percentage);

            controller.AddIngredient(ingredient, 10);
            Assert.AreEqual(percentage, controller.GetAlcoholPercentage());
        }
    }

    [Test]
    [TestCase(0.1f + 0.1f, new [] {0.1f, 0.3f}, new[] { 10, 10})]
    [TestCase(0.04f + 0.18f, new[] { 0.1f, 0.3f }, new[] { 20, 30 })]
    public void AddIngredient_AddsMultipleLiquids_UpdatesAlcoholPercentage(float drinkPercentage, float[] ingredientPercentages, int[] ingredientAmounts)
    {
        if (ingredientPercentages.Length != ingredientAmounts.Length)
        {
            return;
        }
        DrinkController controller = new DrinkController();
        for (int i = 0; i < ingredientPercentages.Length; i++)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.SetPercentage(ingredientPercentages[i]);
            controller.AddIngredient(ingredient, ingredientAmounts[i]);
        }

        Assert.AreEqual(drinkPercentage, controller.GetAlcoholPercentage());
    }
}

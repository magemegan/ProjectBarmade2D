using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NPCOrderingTests
{
    [Test]
    public void GetRandomRecipe_ReturnsRecipe()
    {
        NPCOrdering ordering = new NPCOrdering();
        Recipe recipe = ordering.GetRandomRecipe();
        

        Assert.IsNotNull(recipe);
    }

    [Test]
    public void GetRandomRecipe_RecipeIsUnlocked()
    {
        NPCOrdering ordering = new NPCOrdering();
        Recipe randomRecipe = ordering.GetRandomRecipe();
        bool isUnlocked = randomRecipe.getUnlocked();

        Assert.True(isUnlocked);
    }
}
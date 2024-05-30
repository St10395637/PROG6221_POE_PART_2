using System.Collections.Generic;
using Xunit;

namespace POE_Part_2_RecipeApplication.Tests
{
    public class RecipeTests
    {
        [Fact]
        public void AddIngredient_ShouldAddIngredientToList()
        {
            // Arrange
            var recipe = new Recipe();
            var ingredient = new Ingredient("Sugar", 1, "cup", 100, "Sweeteners");

            // Act
            recipe.ingredients.Add(ingredient);

            // Assert
            Assert.Contains(ingredient, recipe.ingredients);
        }

        [Fact]
        public void ScaleRecipe_ShouldScaleQuantities()
        {
            // Arrange
            var recipe = new Recipe();
            var ingredient = new Ingredient("Sugar", 1, "cup", 100, "Sweeteners");
            recipe.ingredients.Add(ingredient);
            float scaleFactor = 2;

            // Act
            recipe.ScaleRecipe(scaleFactor);

            // Assert
            Assert.Equal(2, recipe.ingredients[0].Quantity);
        }

        [Fact]
        public void ResetQuantities_ShouldResetQuantitiesToOne()
        {
            // Arrange
            var recipe = new Recipe();
            var ingredient = new Ingredient("Sugar", 2, "cup", 100, "Sweeteners");
            recipe.ingredients.Add(ingredient);

            // Act
            recipe.ResetQuantities();

            // Assert
            Assert.Equal(1, recipe.ingredients[0].Quantity);
        }
    }
}using System;

public class Class1
{
	public Class1()
	{
	}
}

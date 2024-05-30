using System.Collections.Generic;
using Xunit;

namespace POE_Part_2_RecipeApplication.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void EnterRecipeDetails_ShouldReturnRecipe()
        {
            // Arrange
            var input = new List<string> { "Test Recipe", "1", "Sugar", "1", "cup", "100", "Sweeteners", "1", "Mix ingredients" };
            var inputEnumerator = input.GetEnumerator();
            System.Console.SetIn(new System.IO.StringReader(string.Join("\n", input)));

            // Act
            var recipe = Program.EnterRecipeDetails();

            // Assert
            Assert.Equal("Test Recipe", recipe.Name);
            Assert.Single(recipe.ingredients);
            Assert.Single(recipe.steps);
        }

        [Fact]
        public void DisplayRecipe_ShouldDisplayRecipeDetails()
        {
            // Arrange
            var recipe = new Recipe { Name = "Test Recipe" };
            recipe.ingredients.Add(new Ingredient("Sugar", 1, "cup", 100, "Sweeteners"));
            recipe.steps.Add(new Step("Mix ingredients"));
            var recipes = new List<Recipe> { recipe };

            // Act
            var output = new System.IO.StringWriter();
            System.Console.SetOut(output);
            Program.DisplayRecipe(recipes);

            // Assert
            var result = output.ToString();
            Assert.Contains("Test Recipe", result);
            Assert.Contains("1 cup of Sugar with 100 calories from Sweeteners", result);
            Assert.Contains("Mix ingredients", result);
        }
    }
}
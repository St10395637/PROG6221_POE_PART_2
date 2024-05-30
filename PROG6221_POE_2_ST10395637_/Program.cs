using System;
using System.Collections.Generic;
using System.Linq;

namespace POE_Part_2_RecipeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            bool exit = false;

            //This will loop until the user chooses between the 6 options
            while (!exit)
            {
                Console.WriteLine("______________Menu______________");
                Console.WriteLine("1. Enter the  recipe details");
                Console.WriteLine("2. Display the recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset the quantities");
                Console.WriteLine("5. Clear the all data");
                Console.WriteLine("6. Exit the application");
                Console.WriteLine("_________________________________");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipes.Add(EnterRecipeDetails());
                        break;
                    case 2:
                        DisplayRecipe(recipes);
                        break;
                    case 3:
                        ScaleRecipe(recipes);
                        break;
                    case 4:
                        ResetQuantities(recipes);
                        break;
                    case 5:
                        ClearData(recipes);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static Recipe EnterRecipeDetails()
        {
            Console.WriteLine("___________________________________________");
            Recipe recipe = new Recipe();
            Console.WriteLine("Enter the name of the recipe:");
            recipe.Name = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("___________________________________________");
            // Enter ingredients details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                float quantity = Convert.ToSingle(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                Console.Write("Number of calories: ");
                float calories = Convert.ToSingle(Console.ReadLine());
                Console.Write("Food group: ");
                string foodGroup = Console.ReadLine();

                recipe.ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                Console.WriteLine("___________________________________________");
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            // Enter steps details
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();
                recipe.steps.Add(new Step(description));
            }

            Console.WriteLine("Recipe details entered successfully.");

            return recipe;
            Console.WriteLine("___________________________________________");
        }

        static void DisplayRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("___________________________________________");
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Available recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the number of the recipe to display:");
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < recipes.Count)
            {
                recipes[choice].DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.WriteLine("____________________________________________");
        }

        static void ScaleRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("___________________________________________");
            Console.WriteLine("Enter scale factor (0.5 for half, 2 for double, 3 for triple):");
            float scaleFactor = Convert.ToSingle(Console.ReadLine());

            foreach (var recipe in recipes)
            {
                recipe.ScaleRecipe(scaleFactor);
            }

            Console.WriteLine("Recipe scaled by factor {scaleFactor}.");
            Console.WriteLine("___________________________________________");
        }

        static void ResetQuantities(List<Recipe> recipes)
        {
            Console.WriteLine("___________________________________________");
            foreach (var recipe in recipes)
            {
                recipe.ResetQuantities();
            }

            Console.WriteLine("Quantities reset to original values.");
            Console.WriteLine("___________________________________________");
        }

        static void ClearData(List<Recipe> recipes)
        {
            Console.WriteLine("___________________________________________");
            recipes.Clear();

            Console.WriteLine("All data cleared.");
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<Step> steps { get; set; }

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
        }

        public void ScaleRecipe(float scaleFactor)
        {
            Console.WriteLine("___________________________________________");
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }

            Console.WriteLine($"Recipe scaled by factor {scaleFactor}.");
            Console.WriteLine("___________________________________________");
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = 1;
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("___________________________________________");
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} with {ingredient.Calories} calories from {ingredient.FoodGroup}");
            }

            Console.WriteLine("Steps:");
            foreach (var step in steps)
            {
                Console.WriteLine($"{step.Description}");
            }
            Console.WriteLine("___________________________________________");
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public float Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, float quantity, string unit, float calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }

}
# PROG6221_POE_PART_2

This is a recipe management application written in C#.

It allows users to enter, display, scale, reset quantities and delete recipe data.

Features:
Enter recipe details including name, ingredients (quantity, unit, name, calories, food group) and steps.
Display a list of available recipes and information about the selected recipe.
Scale the amount of ingredients in all recipes by a user-defined factor.
Reset all ingredients in all recipes to 1.Delete all recipe data.

To run the app:
Save the code as a .cs file (eg RecipeApp.cs).
Compile and run the code using a C# compiler or IDE.
The application displays a menu with recipe management options.
Follow the on-screen instructions to enter recipe information, select features, and view information.

Code structure:

The code is divided into several classes:

Program: The main class that contains the application loop and menu logic.
Recipe: Represents a recipe with properties for name, ingredients (list of ingredient objects) and steps (list of step objects).
Ingredient: Represents an ingredient with properties for name, quantity, unit, calories, and food group.
Step: Represents a recipe step with a description attribute.

Additional notes:The code currently lacks input validation.Users may enter incorrect information which may cause errors.
Recipe information is not saved. All data will be lost when you close the app.Future improvements:Enable input validation to ensure users enter valid data types and menu options.Add functionality to save recipe data to a file or database for persistence.Improve the user interface with additional capabilities (eg search for recipes, edit existing recipes).

My mistakes from the part 1 was that my scale method did not return the original amount of the digits that were entered, but it is fixed now.

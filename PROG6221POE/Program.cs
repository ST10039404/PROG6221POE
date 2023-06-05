//////////////
// Author: ST10039404
//////////////

using PROG6221POE;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Collections.Generic;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ConsoleRecipe
{
    private Recipe internalRecipe = new Recipe();
    List<Recipe> recipeList = new List<Recipe>();


    ////  Driver Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
    public static void Main()
    {
        //initializes this class as methods are not static.
        ConsoleRecipe recipeApp = new ConsoleRecipe();
        Console.WriteLine("//////////////////////////////////////////////////////////////////////////////\n       >>>       || Hi, Welcome to Sanele's Simple Recipe Maker! ||      <<<        \n//////////////////////////////////////////////////////////////////////////////");
        recipeApp.MainMenu(0);
    }

    public void MainMenu(int currentIndex)
    {
        Console.Write("\n\n/////////////////////////////////////////////\nPlease enter the number and only the number\n/////////////////////////////////////////////\nCurrent Selection: { " + recipeList.ElementAt(currentIndex).getRecipeName() + "\n/////////////////////////////////////////////\n   1.   Create New Recipe\n   2.   Displays Recipe\n   3.   Multiply by a factor\n   5.   Print recipe list (Recipe Selection Option After)\n   6.   Clear current recipe\n   7.   Exit program\n/////////////////////////////////////////////\n   >>>   ");
        //takes value for switch
        int inputVal = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(inputVal);
        //switch directs to other methods in this class (which make use of methods within the Recipe.cs file to perform it's functions)
        switch (inputVal)
        {
            case 1:
                recipeList.Add(GenerateNewRecipe());
                break;
            case 2:
                DisplayRecipe(recipeList.ElementAt(currentIndex));
                break;
            case 3:
                MultiplyFactorial(recipeList.ElementAt(currentIndex), currentIndex);
                break;
            case 4:
                printList(recipeList.ToArray());
                break;
            case 5:
                ClearRecipe(recipeList.ElementAt(currentIndex), currentIndex);
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid entry! Nothing occurred.");
                break;
        }
        MainMenu(currentIndex);
    }

    ////  Driver Methods  ////////////////////////////////////////////////////////////////////////////////////////////////

    ////  Delegate Methods  //////////////////////////////////////////////////////////////////////////////////////////////
    delegate int calCal(object[,] n);
    delegate void caloriesWarn(int n);
    calCal del1 = new calCal(calculateCalories);
    caloriesWarn del2 = new caloriesWarn(checkCalories); 

    public static void checkCalories(int totalCalories)
    {
        if (totalCalories > 300)
            Console.Write("\nNOTICE: The total calories for this recipe exceeds 300");
    }

    public static int calculateCalories(object[,] yourRecipeIngredients)
    {
        int totalCalories = 0;

        for (int i = 0; i < yourRecipeIngredients.GetLength(0); i++)
        {
            totalCalories += Convert.ToInt32(yourRecipeIngredients[i, 4]);
        }

        return totalCalories;
    }
    ////  Delegate Methods  ////////////////////////////////////////////////////////////////////////////////////////////////


    ////  Function Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
    //gets values necessary for Recipe constructor which would include the recipe name, number of ingredients and number of steps.
    public Recipe GenerateNewRecipe()
    {
        string recipeName = " ";
        int numIngredients = 0;
        int numSteps = 0;
        string continueVal;

        //all 3 follow the same format, checks for a continue value (asks if user would like to lock in their choice after displaying value back to them) then has a check for if value would be illegal or mess with array (empty or null)
        //except for method 2 which checks if value is less than 0 (you cant have a ingredient with 0 or less quantity)
        Console.WriteLine("///////////////////");
        continueVal = "n";
        //checks for user validation that they would like to lock in input.
        while (continueVal.ToUpper().Equals("y") == false)
        {
            //checks for invalid entry to illogical entry.
            while (String.IsNullOrWhiteSpace(recipeName))
            {
                Console.Write("\nInput the name of your recipe >>>  ");
                recipeName = Console.ReadLine();
            }
            Console.Write("Is this the name you would like to save?:\n {0} \n (Y) to save entry. Anything else to re-enter.\n  >> ");
            continueVal = Console.ReadLine();
        }

        continueVal = "n";
        while (continueVal.ToUpper().Equals("y") == false)
        {
            while (numIngredients <= 0)
            {
                Console.Write("\n\nInput the number of ingredients >>>  ");
                numIngredients = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Is this the quantity you would like to save?:\n {0} \n (Y) to save entry. Anything else to re-enter.\n  >> ");
            continueVal = Console.ReadLine();
        }

        continueVal = "n";
        while (continueVal.ToUpper().Equals("Y") == false)
        {
            while (numSteps <= 0)
            {
                Console.Write("\n\nInput the number of steps for your recipe >>>  ");
                numSteps = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Is this the measurement you would like to save?:\n {0} \n (Y) to save entry. Anything else to re-enter.\n  >> ");
            continueVal = Console.ReadLine();
        }
        Console.WriteLine("///////////////////");

        Recipe returnedRecipe = new Recipe(recipeName, numIngredients, numSteps);
        return returnedRecipe;
    }


    public void DisplayRecipe(Recipe yourRecipe)
    {
        //checks for empty recipe so it can exit if it is.
        if (yourRecipe == null)
        {
            Console.WriteLine("Error Occured: Recipe is null!");
            return;
        }
        else
        {
            //checks for empty values so it can exit if it is.
            if (yourRecipe.getIngredientsArray() == null || yourRecipe.getStepsArray() == null)
            {
                Console.WriteLine("Error occured: Recipe contains nulls");
                return;
            }
            else
            {
                object[,] yourRecipeIngredients = yourRecipe.getIngredientsArray();
                string[] yourRecipeSteps = yourRecipe.getStepsArray();
                int ingredientTotalCalories = 0;
                int ingredientQuantity;
                string ingredientGroup = "";
                //runs through each index and writes them out into the console.
                Console.Write("\n\n///////////////////\n");
                for (int i = 0; i < yourRecipe.getIngredientsArray().Length; i++)
                {
                    switch (yourRecipeIngredients[i, 5])
                    {
                        case 1:
                            ingredientGroup = "Starchy Food";
                            break;
                        case 2:
                            ingredientGroup = "Vegetables and Fruits";
                            break;
                        case 3:
                            ingredientGroup = "Dairy Products";
                            break;
                        case 4:
                            ingredientGroup = "Meat/Chicken/Fish";
                            break;
                        case 5:
                            ingredientGroup = "Fats and Oils";
                            break;
                    }

                    ingredientTotalCalories += Convert.ToInt32(yourRecipeIngredients[i, 4]);

                    ingredientQuantity = (Convert.ToInt32(yourRecipeIngredients[i, 1]) * Convert.ToInt32(yourRecipeIngredients[i, 3]));
                    Console.Write("\nIngredient {0}: {1} {2} {3}, Calories: {4}, Food Group: {5}", i + 1, yourRecipeIngredients[i, 0], ingredientQuantity, yourRecipeIngredients[i, 2], yourRecipeIngredients[i, 4], ingredientGroup);
                }
                Console.Write("///////////////////\n\n///////////////////\n");
                for (int i = 0; i < yourRecipe.getStepsArray().Length; i++)
                {
                    Console.Write("\n{0}", yourRecipeSteps[i]);
                }
                Console.Write("\n\n///////////////////\nTotal Calories: {0}\n///////////////////\n", ingredientTotalCalories);

                //put calorie warning here
                del2(del1(yourRecipeIngredients));
            }
        }
    }



    //uses the 4th index in every ingredient entry (which when displayed will have an effect on the quantity which shows up) so it would be: quantity * index4 = displayQuantity.
    public void MultiplyFactorial(Recipe yourRecipe, int currentIndex)
    {
        //checks for empty recipe so it can exit if it is.
        if (yourRecipe == null)
        {
            Console.WriteLine("Error Occured: Recipe is null!");
            return;
        }
        else
        {
            //checks for empty values so it can exit if it is.
            if (yourRecipe.getIngredientsArray() == null)
            {
                Console.WriteLine("Error occured: Recipe contains nulls");
                return;
            }
            else
            {
                object[,] yourRecipeIngredients = yourRecipe.getIngredientsArray();
                Console.Write("\n\n\n///////////////////\nPlease enter the number to multiply your\n   1.   Half Ingredients\n   2.   Double ingredients\n   3.   Triple ingredient quantities\n   4.   Return to normal\n Anything else\n  >> ");
                switch (Console.Read())
                {
                    case 1:
                        yourRecipeIngredients[0, 3] = 0.5;
                        Console.WriteLine("Ingredient quantities have been halved\nReturning to main menu.");
                        break;
                    case 2:
                        yourRecipeIngredients[0, 3] = 2;
                        Console.WriteLine("Ingredient quantities have been doubled\nReturning to main menu.");
                        break;
                    case 3:
                        yourRecipeIngredients[0, 3] = 3;
                        Console.WriteLine("Ingredient quantities have been tripled\nReturning to main menu.");
                       break;
                    case 4:
                        yourRecipeIngredients[0, 3] = 1;
                        Console.WriteLine("Ingredient quantities have been returned to normal\nReturning to main menu.");
                        break;
                    default:
                        Console.WriteLine("No changes were made.\nReturning to main menu.");
                        break;

                }
            }
        }
    }

    //turns yourRecipe into a new Recipe which has no entries and no size.
    public void ClearRecipe(Recipe yourRecipe, int currentIndex)
    {
        recipeList.RemoveAt(currentIndex);
        Console.WriteLine("Recipe is now empty.");
    }

    //prints array of recipes.
    public void printList(Recipe[] recipeArray)
    {
        string output = "\n\n\n///////////\nRecipe List\n///////////";
        for (int i = 0; i < recipeArray.Length; i++)
        {
            output += "\n"+(i + 1)+".  "+recipeArray[i].getRecipeName();
        }
        output += "\n///////////\nRecipe List End\n///////////\n";
        Console.Write(output);
    }
    ////  Function Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
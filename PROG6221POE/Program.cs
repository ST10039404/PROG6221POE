//////////////
// Author: ST10039404
//////////////

using PROG6221POE;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ConsoleRecipe
{
    private Recipe yourRecipe = new Recipe();


    ////  Driver Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
    public static void Main()
    {
        //initializes this class as methods are not static.
        ConsoleRecipe listOfRecipes = new ConsoleRecipe();
        Console.WriteLine("//////////////////////////////////////////////////////////////////////////////\n       >>>       || Hi, Welcome to Sanele's Simple Recipe Maker! ||      <<<        \n//////////////////////////////////////////////////////////////////////////////");
        listOfRecipes.MainMenu();
    }
    
    public void MainMenu()
    {

        Console.Write("\n\n/////////////////////////////////////////////\nPlease enter the number and only the number\n/////////////////////////////////////////////\n   1.   Create New Recipe (Will Replace Old Recipe) \n   2.   Displays Recipe\n   3.   Multiply by a factor\n   4.   Clear current recipe\n/////////////////////////////////////////////\n   >>>   ");
        //takes value for switch
        int inputVal = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(inputVal);
        //switch directs to other methods in this class (which make use of methods within the Recipe.cs file to perform it's functions)
        switch (inputVal)
        {
            case 1:
                this.yourRecipe = GenerateNewRecipe();
                MainMenu();
                break;
            case 2:
                DisplayRecipe(yourRecipe);
                MainMenu();
                break;
            case 3:
                MultiplyFactorial(yourRecipe);
                MainMenu();
                break;
            case 4:
                ClearRecipe();
                MainMenu();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid entry! Nothing occurred.");
                MainMenu();
                break;
                }
    }

    ////  Driver Methods  ////////////////////////////////////////////////////////////////////////////////////////////////




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
                int ingredientQuantity;

                //runs through each index and writes them out into the console.
                Console.WriteLine("\n///////////////////");
                for (int i = 0; i < yourRecipe.getIngredientsArray().Length; i++)
                {
                    ingredientQuantity = (Convert.ToInt32(yourRecipeIngredients[i, 1]) * Convert.ToInt32(yourRecipeIngredients[i, 3]));
                    Console.WriteLine("Ingredient {0}: {1} {2} {3}", i + 1, yourRecipeIngredients[i, 0], ingredientQuantity, yourRecipeIngredients[i, 2]);
                }
                Console.WriteLine("\n///////////////////");
                for (int i = 0; i < yourRecipe.getStepsArray().Length; i++)
                {
                    Console.WriteLine("{0}", yourRecipeSteps[i]);
                }
                Console.WriteLine("\n///////////////////\n");
            }
        }
    }

    
    //uses the 4th index in every ingredient entry (which when displayed will have an effect on the quantity which shows up) so it would be: quantity * index4 = displayQuantity.
    public void MultiplyFactorial(Recipe yourRecipe)
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
                        MainMenu();
                        break;
                    case 2:
                        yourRecipeIngredients[0, 3] = 2;
                        Console.WriteLine("Ingredient quantities have been doubled\nReturning to main menu.");
                        MainMenu();
                        break;
                    case 3:
                        yourRecipeIngredients[0, 3] = 3;
                        Console.WriteLine("Ingredient quantities have been tripled\nReturning to main menu.");
                        MainMenu();
                        break;
                    case 4:
                        yourRecipeIngredients[0, 3] = 1;
                        Console.WriteLine("Ingredient quantities have been returned to normal\nReturning to main menu.");
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("No changes were made.\nReturning to main menu.");
                        MainMenu();
                        break;

                }
            }
        }
    }

    //turns yourRecipe into a new Recipe which has no entries and no size.
    public void ClearRecipe()
    {
        this.yourRecipe = new Recipe();
        Console.WriteLine("Recipe is now empty.");
    }
    ////  Function Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
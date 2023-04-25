//////////////
// Author: ST10039404
//////////////

using System;
using System.ComponentModel;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ConsoleRecipe
{
    private Recipe yourRecipe;

    public static void Main()
    {
        ConsoleRecipe listOfRecipes = new ConsoleRecipe();
        Console.WriteLine("Hi, Welcome to Sanele's Simple Recipe Maker!");
        listOfRecipes.MainMenu();

    }

public void MainMenu()
    {
        
        Console.Write("\n\n/////////////////////////////////////////////\nPlease enter the number and only the number\n/////////////////////////////////////////////\n   1.   Create New Recipe (Will Replace Old Recipe) \n   2.   Displays Recipe\n   3.   Multiply by a factor\n/////////////////////////////////////////////\n   >>>   ");
        int inputVal = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(inputVal);
        switch (inputVal)
        {
            case 1:
                this.yourRecipe = GenerateNewRecipe();
                break;
            case 2:
                DisplayRecipe(yourRecipe);
                break;
            case 3:
                MultiplyFactorial(yourRecipe);
                break;
            default:
                MainMenu();
                Console.WriteLine("Defaulted!");
                break;
        }
    }

    public Recipe GenerateNewRecipe()
    {
        string recipeName = null;
        int numIngredients = 0;
        int numSteps = 0;

        Console.WriteLine("///////////////////");
        while (recipeName == null)
        {
            Console.Write("\nInput the name of your recipe >>>  ");
            recipeName = Console.ReadLine();
        }

        //turn into try parse
        while (numIngredients <= 0)
        {
            Console.Write("\n\nInput the number of ingredients >>>  ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
        }

        while (numSteps <= 0)
        {
            Console.Write("\n\nInput the number of steps for your recipe >>>  ");
            numSteps = Convert.ToInt32(Console.Read());
        }
        Console.WriteLine("///////////////////");

        Recipe returnedRecipe = new Recipe(recipeName,numIngredients, numSteps);
        return returnedRecipe;
    }

public void DisplayRecipe(Recipe yourRecipe)
    {
        object[][] yourRecipeIngredients = yourRecipe.getIngredientsArray(); 
        string[] yourRecipeSteps = yourRecipe.getStepsArray();
        int ingredientQuantity;



        for (int i = 0; i < yourRecipe.getIngredientsArray().Length; i++)
        {
            ingredientQuantity = (Convert.ToInt32(yourRecipeIngredients[i][1]) * Convert.ToInt32(yourRecipeIngredients[i][3]));
            Console.WriteLine("///////////////////\nIngredient {0}: {1} {2} {3}", i+1, yourRecipeIngredients[i][0], ingredientQuantity , yourRecipeIngredients[i][2]);
        }
        
        for (int i = 0; i < yourRecipe.getStepsArray().Length; i++)
        {
            Console.WriteLine("///////////////////\nStep {0}: {1}", i, yourRecipeSteps[i]);
        }

        Console.WriteLine("\n///////////////////\n");
    }

public void MultiplyFactorial(Recipe yourRecipe)
    {
        object[][] yourRecipeIngredients = yourRecipe.getIngredientsArray();
        Console.WriteLine("\n///////////////////\nPlease enter the number to multiply your\n   1.   Half Ingredients\n   2.   Double ingredients\n   3.   Triple ingredient quantities\n   4.   Return to normal\n Anything else");
        switch(Console.Read())
        {
            case 1:
                yourRecipeIngredients[0][3] = 0.5;
                Console.WriteLine("Ingredient quantities have been halved\nReturning to main menu.");
                MainMenu();
                break;
            case 2:
                yourRecipeIngredients[0][3] = 2;
                Console.WriteLine("Ingredient quantities have been doubled\nReturning to main menu.");
                MainMenu();
                break;
            case 3:
                yourRecipeIngredients[0][3] = 3;
                Console.WriteLine("Ingredient quantities have been tripled\nReturning to main menu.");
                MainMenu();
                break;
            case 4:
                yourRecipeIngredients[0][3] = 1;
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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////













////////// RECIPE CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class Recipe
{
    private string recipeName;
    //List<object[]> ingredientsArray = new List<object[]>();
    private static readonly object[] value = { };
    private object[][] recipeIngredientsArray = new object[][] { };
    private string[] recipeStepsArray;


    ///////  CONSTRUCTORS  /////////////////////////////////////////////////////////////////////////////////////////////////     
    public Recipe()
        {
        }

    public Recipe(string recipeName, int numIngredients, int numSteps)
        {
            this.recipeName = recipeName;
            createIngredientsArray(numIngredients);
            createStepsArray(numSteps);
        }
    ///////  CONSTRUCTORS  /////////////////////////////////////////////////////////////////////////////////////////////////   



    ////  Name Methods  //////////////////////////////////////////////////////////////////////////////////////////////// 
    public void setRecipeName(string recipeName)
    {
        this.recipeName = recipeName;
    }

    public string getRecipeName()
    {
        return this.recipeName;
    }
    ////  Name Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
    


    ////   Ingredients Methods   ////////////////////////////////////////////////////////////////////////////////////////
    public void createIngredientsArray(int numIngredients)
    {
        string ingredientName;
        int ingredientQuantity;
        string ingredientMeasureUnit;

        for (int i = 0; i < numIngredients; i++)
        {
            ingredientName = "";
            ingredientQuantity = 0;
            ingredientMeasureUnit = "";

            bool satisfied = false;
            while (satisfied == false)
            {
                Console.Write("\n\n///////////\nIngredient {0} NAME >> ", i);
                while (String.IsNullOrWhiteSpace(ingredientName))
                {
                    try
                    {
                        ingredientName = Console.ReadLine();
                        Console.WriteLine(ingredientName);
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an invalid value.");
                    }
                }

                Console.Write("\n\nIngredient {0} QUANTITY (without measurement units) >> ", i);
                while (ingredientQuantity <= 0)
                {
                    try
                    {
                        ingredientQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(ingredientQuantity);
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an invalid value.");
                    }
                }

                Console.Write("\n\nIngredient {0} MEASUREMENT UNIT >> ", i);
                while (String.IsNullOrWhiteSpace(ingredientMeasureUnit))
                {
                    try
                    {
                        ingredientMeasureUnit = Console.ReadLine();
                        Console.WriteLine(ingredientMeasureUnit);
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an invalid value.");
                    }
                }

                Console.Write("\n\nIs this satisfactory? 'Y' to continue or anything else to re-enter ingredient details\n >> {0}, {1} {2}  <<\n >> ", ingredientName, ingredientQuantity, ingredientMeasureUnit);
                switch (Console.ReadLine())
                {
                    case "Y" or "y":
                        satisfied = true;
                        break;
                    default:
                        satisfied = false;
                        break;
                }
            }

            setIngredientsObject(i, 0, ingredientName);
            setIngredientsObject(i, 1, ingredientQuantity);
            setIngredientsObject(i, 2, ingredientMeasureUnit);
            setIngredientsObject(i, 3, 1);
            object[][] testIngredients = getIngredientsArray();
            Console.WriteLine(testIngredients[i][0]);
            Console.WriteLine(testIngredients[i][1]);
            Console.WriteLine(testIngredients[i][2]);
            Console.WriteLine(testIngredients[i][3]);

            /*
            this.recipeIngredientsArray[i] = new object[4];
            this.recipeIngredientsArray[i][0] = ingredientName;
            this.recipeIngredientsArray[i][1] = ingredientQuantity;
            this.recipeIngredientsArray[i][2] = ingredientMeasureUnit;
            this.recipeIngredientsArray[i][3] = 1;*/

            //the recipeIngredientsArrray[i][3] will serve as a multiplier which is linked directly to each recipe with a simplified way of returning the factored amount to normal (for the quantity)
        }
    }
        

    public void alterIngredientsArray(int indexAlter, int typeAlter)
        {
            object inputValue = null;
            object savedValue = this.recipeIngredientsArray[indexAlter][typeAlter];
            string cancelVal = " ";
        Console.WriteLine("Please enter the value you would like to be inserted at this location.");
        while (cancelVal != "Y" && inputValue == null)
        {
            try
            {
                inputValue = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Please re-enter a valid value you would like to insert under this location.");
            }
            Console.WriteLine("Would you like to cancel this operation? 'Y' to cancel. Anything else to continue the operation.");
            cancelVal = Console.ReadLine();
        }

        if (cancelVal == "Y" || inputValue == null)
            {
                this.recipeIngredientsArray[indexAlter][typeAlter] = savedValue;
            }
            else
                {
                    this.recipeIngredientsArray[indexAlter][typeAlter] = inputValue;
                }
        
        }

    public void setIngredientsArray(object[][] inputArr)
    {
        this.recipeIngredientsArray = inputArr;
    }

    public void setIngredientsObject(int indexSet, int typeSet, string inputVal)
        {
        this.recipeIngredientsArray[indexSet][typeSet] = inputVal;
        }

    public void setIngredientsObject(int indexSet, int typeSet, int inputVal)
    {
        this.recipeIngredientsArray[indexSet][typeSet] = inputVal;
    }

    public object[][] getIngredientsArray()
        {
            return this.recipeIngredientsArray;
        }

    public object getIngredientsObject(int indexGet, int typeGet)
    {
        return this.recipeIngredientsArray[indexGet][typeGet];
    }
    ////  Ingredients Methods  //////////////////////////////////////////////////////////////////////////////////////////    


    ////  Steps Methods  ////////////////////////////////////////////////////////////////////////////////////////////////    
    public void createStepsArray(int numSteps)
        {
        string continueVal = "Y";
        Console.WriteLine("\n///////////");
            string[] recipeStepsArray = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
            while (continueVal.ToUpper().Equals("Y"))
                {
                Console.WriteLine("Please enter step {0}/{1}  >> ", i + 1, numSteps);
                this.recipeStepsArray[i] += "\nStep" + (i + 1) + " : " + Console.ReadLine();
                Console.WriteLine("Would you like to change this step? \n(Y) or (N)\n\n // {0} \\\\\n\n      >>", recipeStepsArray[i]);
                continueVal = Console.ReadLine();
                Console.WriteLine("///////////");
                }
            }
        }

    public void alterStepsArray(int indexAlter)
        {
            this.recipeStepsArray[indexAlter] = Console.ReadLine();
        }

    public void setStepsArray(int indexAlter, string inputVal)
    {
        this.recipeStepsArray[indexAlter] = inputVal;
    }

    public string[] getStepsArray()
        {
            return this.recipeStepsArray;
        }
    ////  Steps Methods  //////////////////////////////////////////////////////////////////////////////////////////////// 
}
/////// RECIPE CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

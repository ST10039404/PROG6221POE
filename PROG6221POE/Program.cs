//////////////
// Author: ST10039404
//////////////

using System;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ConsoleRecipe
{
    Recipe yourRecipe = new Recipe();
public static void Main()
    {
        ConsoleRecipe listOfRecipes = new ConsoleRecipe();
        Console.WriteLine("Hi, Welcome to Sanele's Simple Recipe Maker!");
        listOfRecipes.MainMenu();

    }

public void MainMenu()
    {
        
        Console.WriteLine("\n\n/////////////////////////////////////////////\nPlease enter the number and only the number\n/////////////////////////////////////////////\n   1.   Create New Recipe (Will Replace Old Recipe) \n   2.   Displays Recipe\n   3.   Multiply by a factor\n/////////////////////////////////////////////");
        switch (Console.Read())
        {
            case 1:
                GenerateNewRecipe();
                break;
            case 2:
                DisplayRecipe();
                break;
            case 3:

                break;
            case 4:
                
            default:
                MainMenu();
                break;
        }
    }

public void GenerateNewRecipe()
    {

    }

public void DisplayRecipe()
    {
        Console.WriteLine("", this.yourRecipe);
    }

public void test()
    {

    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////













////////// START OF CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////// START OF CLASS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class Recipe
{
    private object[][] recipeIngredientsArray;
    private string[] recipeStepsArray;


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     
    public Recipe()
        {
        }

    public Recipe(int numIngredients, int numSteps)
        {
            createIngredientsArray(numIngredients);
            createStepsArray(numSteps);
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     



    ////   Ingredients Methods   ////////////////////////////////////////////////////////////////////////////////////////
    public void createIngredientsArray(int numIngredients)
    {
        string ingredientName = " ";
        int ingredientQuantity = 0;
        string ingredientMeasureUnit = " ";

        for (int i = 0; i < numIngredients; i++)
        {
            bool satisfied = false;
            while (satisfied == false)
            {
                Console.WriteLine("\n///////////\nIngredient {0} NAME >> ", i);
                while (ingredientName == null)
                {
                    try
                    {
                        ingredientName = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an empty value.");
                    }
                }

                Console.WriteLine("Ingredient {0} QUANTITY (without measurement units) >> ", i);
                while (ingredientQuantity == null)
                {
                    try
                    {
                        ingredientQuantity = Console.Read();
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an empty value.");
                        Console.ReadLine();
                    }
                }

                Console.WriteLine("Ingredient {0} MEASUREMENT UNIT >> ", i);
                while (ingredientMeasureUnit == null)
                {
                    try
                    {
                        ingredientMeasureUnit = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid value, the output returned an empty value.");
                        Console.ReadLine();
                    }
                }
            }

            this.recipeIngredientsArray[i][0] = ingredientName;
            this.recipeIngredientsArray[i][1] = ingredientQuantity;
            this.recipeIngredientsArray[i][2] = ingredientMeasureUnit;
            this.recipeIngredientsArray[i][3] = 1;
            //the recipeIngredientsArrray[i][3] will serve as a multiplier which is linked directly to each recipe with a simplified way of returning the factored amount to normal (for the quantity)

            Console.WriteLine("Is this satisfactory? 'Y' to continue or anything else to re-enter ingredient details\n >> {0}, {1} {2}  <<", ingredientName, ingredientQuantity, ingredientMeasureUnit);
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

    public void setIngredientsArray(int indexAlter, int typeAlter, string inputVal)
        {
        this.recipeIngredientsArray[indexAlter][typeAlter] = inputVal;
        }

    public object[][] getIngredientsArray()
        {
            return this.recipeIngredientsArray;
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
/////// END OF CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////// END OF CLASS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

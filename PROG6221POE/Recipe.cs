//////////////
// Author: ST10039404
//////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221POERecipe
{
    ////////// RECIPE CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Recipe
    {
        private string recipeName;
        private object[,] recipeIngredientsArray;
        private string[] recipeStepsArray;


        ///////  CONSTRUCTORS  /////////////////////////////////////////////////////////////////////////////////////////////////    
        public Recipe()
        {
        }

        //inputs name of recipe then uses methods in order to keep constructor visually compact and improve modularity of the methods within (allowing them to be used individually if need be) 
        public Recipe(string recipeName, int numIngredients, int numSteps)
        {
            this.recipeName = recipeName;
            createIngredientsArray(numIngredients);
            createStepsArray(numSteps);
        }
        ///////  CONSTRUCTORS  /////////////////////////////////////////////////////////////////////////////////////////////////  



        ////  Name Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
        //setters and getters
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
            this.recipeIngredientsArray = new object[numIngredients, 6];

            string ingredientName;
            int ingredientQuantity;
            string ingredientMeasureUnit;
            int ingredientCalories;
            int ingredientFoodGroup;

            for (int i = 0; i < numIngredients; i++)
            {
                //resets values so that error checking will be enabled.
                ingredientName = " ";
                ingredientQuantity = -1;
                ingredientMeasureUnit = " ";
                ingredientCalories = -1;
                ingredientFoodGroup = -1;
                bool satisfied = false;
                //as long as user doesent enter Y when asking if they are satisfied, this loop will continously ask for details regarding this step.
                while (satisfied == false)
                {
                    ingredientName = " ";
                    ingredientQuantity = -1;
                    ingredientMeasureUnit = " ";
                    ingredientCalories = -1;
                    ingredientFoodGroup = -1;

                    Console.Write("\n\n///////////\nIngredient {0} NAME \n  >> ", i + 1);
                    //checks for nulls (not really useful) but also checks if its a white space (which would be illogical) and uses that as the reason to continue asking for a new value.
                    while (String.IsNullOrWhiteSpace(ingredientName))
                    {
                        ingredientName = Console.ReadLine();
                        Console.WriteLine(ingredientName);
                    }

                    Console.Write("\n\nIngredient {0} QUANTITY (without measurement units) \n  >> ", i + 1);
                    //checks for if the quantity is 0 or less (which you cant have an ingredient of 0 quantity) and uses that as the reason to continue asking for a new value.
                    while (ingredientQuantity <= 0)
                    {
                        ingredientQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(ingredientQuantity);
                    }

                    Console.Write("\n\nIngredient {0} MEASUREMENT UNIT \n  >> ", i + 1);
                    //checks for nulls (not really useful) but also checks if its a white space (which would be illogical) and uses that as the reason to continue asking for a new value.
                    while (String.IsNullOrWhiteSpace(ingredientMeasureUnit))
                    {
                        ingredientMeasureUnit = Console.ReadLine();
                        Console.WriteLine(ingredientMeasureUnit);
                    }

                    Console.Write("\n\nIngredient {0} CALORIE QUANTITY \n  >> ", i + 1);
                    //checks for nulls (not really useful) but also checks if its a white space (which would be illogical) and uses that as the reason to continue asking for a new value.
                    while (String.IsNullOrWhiteSpace(ingredientMeasureUnit))
                    {
                        ingredientMeasureUnit = Console.ReadLine();
                        Console.WriteLine(ingredientCalories);
                    }

                    Console.Write("\n\nIngredient {0} FOOD GROUP (Select Number)\n 1. Starchy Food\n 2. Vegetables and Fruits\n 3. Dairy Product\n 4. Meat/Chicken/Fish\n 5. Fats and Oils\n  >> ", i + 1);
                    //checks for nulls (not really useful) but also checks if its a white space (which would be illogical) and uses that as the reason to continue asking for a new value.
                    while (ingredientFoodGroup <= 0 || ingredientFoodGroup > 5)
                    {
                        ingredientMeasureUnit = Console.ReadLine();
                        Console.WriteLine(ingredientFoodGroup);
                    }

                    Console.Write("\n\nIs this satisfactory? 'Y' to continue or anything else to re-enter ingredient details\n >> {0}, {1} {2}  <<\n  >> ", ingredientName, ingredientQuantity, ingredientMeasureUnit);
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
                //just sets values.
                setIngredientsObject(i, 0, ingredientName);
                setIngredientsObject(i, 1, ingredientQuantity);
                setIngredientsObject(i, 2, ingredientMeasureUnit);
                setIngredientsObject(i, 3, 1);
                setIngredientsObject(i, 5, ingredientCalories);
                setIngredientsObject(i, 6, ingredientFoodGroup);
                //the recipeIngredientsArrray[i,3] will serve as a multiplier which is linked directly to displaying of each recipe with a simplified way of changing factored amount or returning the factored amount to normal (for the quantity)
            }
        }

        //user-friendlier way of inputting new values at specific locations (currently unused)
        public void alterIngredientsArray(int indexAlter, int typeAlter)
        {
            object inputValue = null;
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

            //checks if user cancelled or the input is simply invalid, and if true will leave the value unchanged.
            if (cancelVal == "Y" || inputValue == null)
            {
                Console.WriteLine("Either you cancelled or the value entered was null!");
            }
            else
            {
                this.recipeIngredientsArray[indexAlter, typeAlter] = inputValue;
            }

        }
        //setters and getters for ingredients. IngredientsArray variants will replace the entire array with an input array or get the entire Recipe.recipeIngredeintsArray array
        //and IngredientsObject will only replace one object at one index.
        public void setIngredientsArray(object[,] inputArr)
        {
            this.recipeIngredientsArray = inputArr;
        }

        public void setIngredientsObject(int indexSet, int typeSet, string inputVal)
        {
            this.recipeIngredientsArray[indexSet, typeSet] = inputVal;
        }

        public void setIngredientsObject(int indexSet, int typeSet, int inputVal)
        {
            this.recipeIngredientsArray[indexSet, typeSet] = inputVal;
        }

        public object[,] getIngredientsArray()
        {
            return this.recipeIngredientsArray;
        }

        public object getIngredientsObject(int indexGet, int typeGet)
        {
            return this.recipeIngredientsArray[indexGet, typeGet];
        }
        ////  Ingredients Methods  //////////////////////////////////////////////////////////////////////////////////////////    


        ////  Steps Methods  ////////////////////////////////////////////////////////////////////////////////////////////////    
        public void createStepsArray(int numSteps)
        {
            this.recipeStepsArray = new string[numSteps];

            string continueVal;
            string recipeStep = "";

            Console.WriteLine("\n///////////");
            for (int i = 0; i < numSteps; i++)
            {
                //after you type Y to save step the continue val must be reset in order to make the while loop run at least once.
                continueVal = " ";
                while (continueVal.ToUpper().Equals("Y") == false)
                {
                    Console.WriteLine("Please enter step {0}/{1}  >> ", i + 1, numSteps);
                    recipeStep = "\nStep" + (i + 1) + " : " + Console.ReadLine();
                    Console.Write("\nWould you like to save this step? \n(Y) to confirm or anything else to re-enter.\n\n{0}\n\n      >>  ",recipeStep);
                    continueVal = Console.ReadLine();
                    Console.WriteLine("///////////");
                }
                setStepsObject(i, recipeStep);
            }

        }
        
        //user friendly way of inputing new values at specific locations. (currently unused)
        public void alterStepsObject(int indexAlter)
        {
            string inputValue = null;
            string savedValue = this.recipeStepsArray[indexAlter];
            string cancelVal = " ";
            this.recipeStepsArray[indexAlter] = Console.ReadLine();
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

            //checks if user cancelled or the input is simply invalid, and if true will leave the value unchanged.
            if (cancelVal == "Y" || inputValue == null)
            {
                Console.WriteLine("Either you cancelled or the value entered was null!");
            }
            else
            {
                this.recipeStepsArray[indexAlter] = inputValue;
            }
        }

        //setters and getters for ingredients. IngredientsArray variants will replace the entire array with an input array or get the entire Recipe.recipeIngredeintsArray array
        //and IngredientsObject will only replace one object at one index.
        public void setStepsObject(int indexAlter, string inputVal)
        {
            this.recipeStepsArray[indexAlter] = inputVal;
        }

        public string getStepsObject(int indexAlter)
        {
            return this.recipeStepsArray[indexAlter];
        }
        public void setStepsArray(string[] inputVal)
        {
            this.recipeStepsArray = inputVal;
        }
        public string[] getStepsArray()
        {
            return this.recipeStepsArray;
        }
        ////  Steps Methods  ////////////////////////////////////////////////////////////////////////////////////////////////
    }
    /////// RECIPE CLASS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

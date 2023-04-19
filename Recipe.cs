﻿using System;

public class Recipe
{
    private string[] RecipeIngredientsArray;
    private string[] RecipeStepsArray;

    public Recipe()
	{
	}

    public Recipe(int numIngredients, int numSteps)
	{
		this.RecipeIngredientsArray = string[] RecipeIngredients = new string[numIngredients];
		createIngredientsArray(numIngredients);
		this.RecipeStepsArray = string[] RecipeSteps = new string[numSteps];
	}


    public void createIngredientsArray(int numIngredients)
	{
		for (int i = 0; i < numIngredients; i++)
		{
			Console.WriteLine("Ingredient {0} NAME >> ", i);
			this.RecipeIngredientsArray[i] = "Ingredient 1:"+Console.ReadLine();
            Console.WriteLine("Ingredient {0} QUANTITY >> ", i);
			this.RecipeIngredientsArray[i] += " " + Console.ReadLine();
			Console.WriteLine("Ingredient {0} MEASUREMENT UNIT >> ", i);
			this.RecipeIngredientsArray[i] += " " + Console.ReadLine();
		}
	}

	public void alterIngredientsArray(int indexAlter, string[] RecipeIngredientsArray)
	{
		RecipeIngredientsArray[indexAlter] = Console.ReadLine();
	}

	public string[] getIngredientsArray()
	{
		return this.RecipeIngredientsArray;
	}



	public void createStepsArray(int numSteps)
	{
		string[] RecipeStepsArray = new string[numSteps]; 
		RecipeStepsArray[0] = "";
		for (int i = 0; i < numSteps; i ++)
		{
			Console.WriteLine("Please enter step {0}/{1}  >> ", i+1,numSteps);
			RecipeStepsArray[i] += "\nStep"+(i+1)+" : "+Console.ReadLine();
		}
		this.RecipeStepsArray = RecipeStepsArray;
	}

	public void alterStepsArray(int indexAlter, string[] RecipeStepsArray)
	{
		RecipeStepsArray[indexAlter] = Console.ReadLine();
	}

	public string[] getStepsArray()
	{
		return this.RecipeStepsArray;
	}
}

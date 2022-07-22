using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    private readonly RecipesService _rs;

    public IngredientsService(IngredientsRepository repo, RecipesService rs)
    {
      _repo = repo;
      _rs = rs;
    }

    internal Ingredient GetIngredientById(int id)
    {
      Ingredient target = _repo.GetIngredientById(id);
      if (target == null)
      {
        throw new Exception("invalid Id");
      }
      return target;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
      Recipe targetRecipe = _rs.GetById(ingredientData.RecipeId);
      if (targetRecipe.CreatorId != userId)
      {
        throw new System.Exception("You cannot add an ingredient to another person's recipe");
      }
      return _repo.CreateIngredient(ingredientData);
    }

    internal ActionResult<string> DeleteIngredient(int ingredientId, string userId)
    {
      Ingredient targetIngredient = GetIngredientById(ingredientId);
      Recipe targetRecipe = _rs.GetById(targetIngredient.Id);
      if (targetRecipe.CreatorId != userId)
      {
        throw new System.Exception("Can't delete ingredients on recipes that don't belong to you.");
      }
      return _repo.DeleteIngredient(ingredientId);
    }

    internal List<Ingredient> GetRecipeIngredients(int id)
    {
      return _repo.GetRecipeIngredients(id);
    }
  }
}
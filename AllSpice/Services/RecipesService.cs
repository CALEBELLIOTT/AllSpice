using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Services
{
  public class RecipesService
  {

    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository rs)
    {
      _repo = rs;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      return _repo.CreateRecipe(recipeData);
    }

    internal List<Recipe> GetAll()
    {
      return _repo.GetAll();
    }

    internal Recipe GetById(int id)
    {
      return _repo.GetById(id);
    }

    internal ActionResult<Recipe> UpdateRecipe(int recipeId, Recipe recipeData)
    {
      Recipe target = GetById(recipeId);
      if (target.CreatorId != recipeData.CreatorId)
      {
        throw new Exception("Not authorized");
      }
      target.Picture = recipeData.Picture ?? target.Picture;
      target.Title = recipeData.Title ?? target.Title;
      target.Subtitle = recipeData.Subtitle ?? target.Subtitle;
      target.Category = recipeData.Category ?? target.Category;

      return _repo.UpdateRecipe(target);
    }
  }
}
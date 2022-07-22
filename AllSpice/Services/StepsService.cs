using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Services
{
  public class StepsService
  {
    private readonly RecipesService _rs;
    private readonly StepsRepository _repo;

    public StepsService(RecipesService rs, StepsRepository repo)
    {
      _rs = rs;
      _repo = repo;
    }

    internal ActionResult<Step> CreateStep(Step stepData, string userId)
    {
      Recipe targetRecipe = _rs.GetById(stepData.RecipeId);
      if (targetRecipe.CreatorId != userId)
      {
        throw new System.Exception("Cannot add a step to another person's recipe");
      }
      return _repo.CreateStep(stepData);
    }

    internal List<Step> GetRecipeSteps(int recipeId)
    {
      return _repo.getRecipeSteps(recipeId);
    }

    internal ActionResult<Step> GetStepById(int id)
    {
      Step step = _repo.GetStepById(id);
      if (step == null)
      {
        throw new Exception("Invalid step Id");
      }
      return step;
    }

    internal ActionResult<string> DeleteStep(int stepId, string userId)
    {
      Step targetStep = _repo.GetStepById(stepId);
      Recipe targetRecipe = _rs.GetById(targetStep.RecipeId);
      if (userId != targetRecipe.CreatorId)
      {
        throw new Exception("Cannot delete steps on a recipe that is not yours");
      }
      return _repo.DeleteStep(stepId);
    }
  }
}
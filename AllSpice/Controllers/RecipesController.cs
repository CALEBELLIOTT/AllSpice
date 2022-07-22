using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _is;
    private readonly StepsService _ss;

    public RecipesController(RecipesService rs, IngredientsService @is, StepsService ss)
    {
      _rs = rs;
      _is = @is;
      _ss = ss;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipeAsync([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.CreatorId = userInfo.Id;
        Recipe recipe = _rs.CreateRecipe(recipeData);
        recipe.Creator = userInfo;
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
      try
      {
        Recipe recipe = _rs.GetById(id);
        return recipe;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredients(int id)
    {
      try
      {
        Recipe targetRecipe = _rs.GetById(id);
        if (targetRecipe == null)
        {
          throw new System.Exception("invalid recipe Id");
        }
        List<Ingredient> ingredients = _is.GetRecipeIngredients(id);
        return Ok(ingredients);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/steps")]
    public ActionResult<List<Step>> GetSteps(int id)
    {
      try
      {
        Recipe targetRecipe = _rs.GetById(id);
        if (targetRecipe == null)
        {
          throw new System.Exception("invalid recipe Id");
        }
        List<Step> steps = _ss.GetRecipeSteps(id);
        return Ok(steps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Recipe>> UpdateRecipeAsync(int id, [FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.Id = id;
        recipeData.CreatorId = userInfo.Id;
        return _rs.UpdateRecipe(id, recipeData);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteRecipeAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _rs.DeleteRecipe(id, userInfo.Id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
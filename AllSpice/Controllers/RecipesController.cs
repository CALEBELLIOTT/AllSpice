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

    public RecipesController(RecipesService rs)
    {
      _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> createRecipeAsync([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.creatorId = userInfo.Id;
        Recipe recipe = _rs.createRecipe(recipeData);
        recipe.Creator = userInfo;
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
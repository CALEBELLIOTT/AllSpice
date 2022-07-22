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
  public class IngredientsController : ControllerBase
  {

    private readonly IngredientsService _is;

    public IngredientsController(IngredientsService @is)
    {
      _is = @is;
    }

    [HttpGet("{id}")]
    public ActionResult<Ingredient> GetIngredientById(int id)
    {
      try
      {
        Ingredient target = _is.GetIngredientById(id);
        return Ok(target);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredientAsync([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Ingredient ingredient = _is.CreateIngredient(ingredientData, userInfo.Id);
        return Ok(ingredient);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteIngredientAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _is.DeleteIngredient(id, userInfo.Id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
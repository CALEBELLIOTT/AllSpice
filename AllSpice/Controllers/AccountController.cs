using System;
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
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly FavoritesService _fs;
    private readonly RecipesService _rs;

    public AccountController(AccountService accountService, FavoritesService fs, RecipesService rs)
    {
      _accountService = accountService;
      _fs = fs;
      _rs = rs;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("favorites")]
    [Authorize]
    public async Task<ActionResult<List<FavoriteRecipeViewModel>>> GetFavoritedRecipesAsync()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _fs.GetFavoritedRecipes(userInfo.Id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("recipes")]
    public async Task<ActionResult<List<Recipe>>> GetAccountRecipesAsync()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Recipe> recipes = _rs.GetAccountRecipes(userInfo.Id);
        return recipes;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}
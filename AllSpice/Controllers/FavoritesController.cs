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
  public class FavoritesController : ControllerBase
  {

    private readonly FavoritesService _fs;

    public FavoritesController(FavoritesService fs)
    {
      _fs = fs;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavoriteAsync([FromBody] Favorite favoriteData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        favoriteData.AccountId = userInfo.Id;
        return _fs.CreateFavorite(favoriteData);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
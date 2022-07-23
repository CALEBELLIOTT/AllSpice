using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Services
{

  public class FavoritesService
  {

    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }

    internal ActionResult<Favorite> CreateFavorite(Favorite favoriteData)
    {
      Favorite targetFavorite = _repo.FindFavorite(favoriteData);
      if (targetFavorite == null)
      {
        return _repo.CreateFavorite(favoriteData);
      }
      return _repo.DeleteFavorite(targetFavorite);
    }

    internal ActionResult<List<FavoriteRecipeViewModel>> GetFavoritedRecipes(string accountId)
    {
      return _repo.GetFavoritedRecipes(accountId);
    }
  }
}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Repositories
{

  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Favorite FindFavorite(Favorite favoriteData)
    {
      string sql = @"
      SELECT * FROM favorites WHERE accountId = @AccountId AND recipeId = @RecipeId;
      ";
      return _db.QueryFirstOrDefault<Favorite>(sql, favoriteData);
    }

    internal ActionResult<Favorite> CreateFavorite(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      Values
      (@AccountId, @recipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }

    internal ActionResult<List<FavoriteRecipeViewModel>> GetFavoritedRecipes(string accountId)
    {
      string sql = @"
      SELECT
        r.*,
        f.id AS FavoriteId
      FROM favorites f
      JOIN recipes r ON r.id = f.recipeId
      WHERE f.accountId = @accountId;
      ";
      return _db.Query<FavoriteRecipeViewModel>(sql, new { accountId }).ToList();
    }

    internal ActionResult<Favorite> DeleteFavorite(Favorite favorite)
    {
      string sql = @"
      DELETE FROM favorites WHERE id = @Id LIMIT 1
      ";
      _db.Execute(sql, favorite);
      return favorite;
    }
  }
}
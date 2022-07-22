using System.Data;
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
      ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }

    internal ActionResult<Favorite> DeleteFavorite(Favorite favorite)
    {
      string sql = @"
      REMOVE * FROM favorites WHERE id = @Id
      ";
      _db.Execute(sql, favorite);
      return favorite;
    }
  }
}
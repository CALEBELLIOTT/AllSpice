using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes
      (picture, title, subtitle, category, creatorId)
      VALUES
      (@Picture, @Title, @Subtitle, @Category, @creatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }

    internal Recipe GetById(int id)
    {
      string sql = @"
      SELECT
        r.*,
        a.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @id
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, acct) =>
      {
        recipe.Creator = acct;
        return recipe;
      }, new { id }).FirstOrDefault();
    }

    internal List<Recipe> GetAll()
    {
      string sql = @"
      SELECT
        r.*,
        a.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id;
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, acct) =>
      {
        recipe.Creator = acct;
        return recipe;
      }).ToList();
    }

    internal ActionResult<string> DeleteRecipe(int id)
    {
      string sql = @"
      DELETE FROM recipes WHERE id = @id LIMIT 1
      ";
      _db.Execute(sql, new { id });
      string res = "delorted";
      return res;
    }

    internal Recipe UpdateRecipe(Recipe RecipeData)
    {
      string sql = @"
      UPDATE recipes
      SET
        picture = @Picture,
        title = @Title,
        subtitle = @Subtitle,
        category = @Category
      WHERE id = @Id
      ";
      _db.Execute(sql, RecipeData);
      return RecipeData;
    }
  }
}
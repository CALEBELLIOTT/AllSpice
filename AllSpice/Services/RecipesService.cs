using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {

    private readonly RecipesRepository _rs;

    public RecipesService(RecipesRepository rs)
    {
      _rs = rs;
    }

    internal Recipe createRecipe(Recipe recipeData)
    {
      return _rs.createRecipe(recipeData);
    }
  }
}
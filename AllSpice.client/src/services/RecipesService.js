import { AppState } from "../AppState"
import { api } from "./AxiosService"

class RecipesService {

  async getAll() {
    const res = await api.get('api/recipes')
    AppState.allRecipes = res.data
    console.log(AppState.allRecipes);
  }

  async getCreatedRecipes() {

  }

  async getRecipeById(id) {
    const res = await api.get('api/recipes/' + id)
    console.log(res.data);
    AppState.activeRecipe = res.data
  }

  async createRecipe(recipeData) {
    recipeData.creatorId = AppState.account.id
    const res = await api.post('api/recipes', recipeData)
    AppState.allRecipes.push(res.data)
    console.log(res.data);
  }


}

export const recipesService = new RecipesService()
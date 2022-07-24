import { AppState } from "../AppState"
import { api } from "./AxiosService"

class RecipesService {

  async getAll() {
    const res = await api.get('api/recipes')
    AppState.allRecipes = res.data
    console.log(AppState.allRecipes);
  }
}

export const recipesService = new RecipesService()
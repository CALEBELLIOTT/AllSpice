import { AppState } from "../AppState"
import { api } from "./AxiosService"

class RecipesService {

  async getAll() {
    const res = await api.get('api/recipes')
    AppState.allRecipes = res.data
  }
}

export const recipesService = new RecipesService()
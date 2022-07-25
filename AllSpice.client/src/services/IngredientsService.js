import { AppState } from "../AppState";
import { api } from "./AxiosService"

class IngredientsService {


  async getRecipeIngredients(id) {
    const res = await api.get("api/recipes/" + id + "/ingredients")
    console.log(res.data);
    AppState.activeRecipeIngredients = res.data
  }

  async createIngredient(data, recipeId) {
    console.log(recipeId);
    data.recipeId = recipeId
    const res = await api.post('api/ingredients', data)
    AppState.activeRecipeIngredients.push(res.data)
  }
}

export const ingredientsService = new IngredientsService
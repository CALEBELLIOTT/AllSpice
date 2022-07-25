import { AppState } from "../AppState";
import { api } from "./AxiosService"

class IngredientsService {


  async getRecipeIngredients(id) {
    const res = await api.get("api/recipes/" + id + "/ingredients")
    console.log(res.data);
    AppState.activeRecipeIngredients = res.data
  }
}

export const ingredientsService = new IngredientsService
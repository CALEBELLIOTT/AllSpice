import { AppState } from "../AppState";
import { api } from "./AxiosService"

class StepsService {

  async getRecipeSteps(id) {
    const res = await api.get("api/recipes/" + id + "/steps")
    console.log(res.data);
    AppState.activeRecipeSteps = res.data
  }

  async createStep(data, recipeId) {
    console.log(recipeId);
    data.recipeId = recipeId
    const res = await api.post('api/steps', data)
    AppState.activeRecipeSteps.push(res.data)
  }
}

export const stepsService = new StepsService
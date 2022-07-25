import { AppState } from "../AppState";
import { api } from "./AxiosService"

class StepsService {

  async getRecipeSteps(id) {
    const res = await api.get("api/recipes/" + id + "/steps")
    console.log(res.data);
    AppState.activeRecipeSteps = res.data
  }
}

export const stepsService = new StepsService
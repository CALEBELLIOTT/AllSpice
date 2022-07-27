import { AppState } from "../AppState";
import { api } from "./AxiosService"


class FavoritesService {


  async getAllFavorites() {
    const res = await api.get("account/favorites")
    console.log(res.data);
    AppState.accountFavorites = res.data
  }
}

export const favoritesService = new FavoritesService()
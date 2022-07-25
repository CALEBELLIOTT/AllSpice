<template>
  <div class="container-fluid">
    <heroImage></heroImage>

    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <NavButtons></NavButtons>
      </div>
    </div>



    <div class="row">
      <div class="col-md-4 d-flex justify-content-center align-items-center" v-for="r in recipes" :key="r.id">
        <Recipe :recipe="r"></Recipe>
      </div>
    </div>
    <RecipeModal></RecipeModal>


    <CreateRecipeModal></CreateRecipeModal>

  </div>
</template>

<script>
import { computed } from "vue"
import { AppState } from "../AppState"

export default {
  setup() {
    let recipes = computed(() => AppState.allRecipes)
    return {
      recipes
    }
  }
}
</script>

<style scoped lang="scss">
</style>

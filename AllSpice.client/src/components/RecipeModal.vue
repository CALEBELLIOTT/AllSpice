
<template>
  <!-- Button trigger modal -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
    Launch demo modal
  </button> -->

  <!-- Modal -->
  <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl">
      <div class="modal-content">
        <div class="modal-body p-0 rounded">
          <div class="row">
            <div class="col-md-6">
              <div class="recipe-img" :style="`background-image: url(${recipe.picture});`">
              </div>
            </div>
            <div class="col-md-6 p-2">
              <div class="row">
                <div class="col-md-12">
                  <h1 class="text-primary m-0">{{ recipe.title }}</h1>
                  <p class="text-muted">{{ recipe.subtitle }}</p>
                </div>
                <div class="col-md-6">
                  <div class="recipe-card mx-2">
                    <h3 class="text-center bg-secondary rounded-top p-2">Recipe Steps</h3>
                    <p v-for="s in steps" :key="s.id">{{ s.position }}) {{ s.body }}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue"
import { AppState } from "../AppState"

export default {
  setup() {
    let recipe = computed(() => AppState.activeRecipe)
    let steps = computed(() => AppState.activeRecipeSteps)
    let ingredients = computed(() => AppState.activeRecipeIngredients)
    return {
      recipe,
      steps,
      ingredients
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-img {
  min-height: 60vh;
  background-size: cover;
  background-position: center;
}

.recipe-card {
  box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
}
</style>

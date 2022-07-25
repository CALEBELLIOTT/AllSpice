
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
              <div class="recipe-img rounded-start" :style="`background-image: url(${recipe.picture});`">
              </div>
            </div>
            <div class="col-md-6">
              <div class="row">
                <div class="col-md-12">
                  <h1 class="text-primary m-0">{{ recipe.title }}</h1>
                  <p class="text-muted">{{ recipe.subtitle }} <br>By: {{ recipe.creator?.name }}</p>
                </div>
                <div class="col-md-6">
                  <div class="recipe-card mx-2">
                    <h3 class="text-center bg-secondary rounded-top p-2">Recipe Steps</h3>
                    <p v-for="s in steps" :key="s.id">{{ s.position }}) {{ s.body }}</p>
                    <form action="" v-if="recipe.creator?.id == account.id" @submit.prevent="createStep()"
                      id="stepForm">
                      <p class="m-0 text-muted font-weight-light">Create a new step</p>
                      <div class=" mb-2">
                        <input type="number" class="form-control" placeholder="Step Position"
                          v-model="stepData.position">
                        <input type="text" class="form-control" placeholder="Step Body..." aria-label="step body"
                          aria-describedby="button-addon2" v-model="stepData.body">
                        <div class="d-flex justify-content-end">
                          <button class="btn btn-secondary m-2" type="submit"><i class="mdi mdi-plus"></i></button>
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="recipe-card mx-2">
                    <h3 class="text-center bg-secondary rounded-top p-2">Recipe Ingredients</h3>
                    <p v-for="i in ingredients" :key="i.id">{{ i.quantity }}, {{ i.name }}</p>
                    <form action="" v-if="recipe.creator?.id == account.id" @submit.prevent="createIngredient()"
                      id="ingredientForm">
                      <p class="m-0 text-muted font-weight-light">Create a new ingredient</p>
                      <input type="text" class="form-control" placeholder="ingredient..." aria-label="step body"
                        aria-describedby="button-addon2" v-model="ingredientData.name">
                      <input type="text" class="form-control" placeholder="ingredient quantity..."
                        aria-label="step body" aria-describedby="button-addon2" v-model="ingredientData.quantity">
                      <div class="d-flex justify-content-end">
                        <button class="btn btn-secondary m-2" type="submit"><i class="mdi mdi-plus"></i></button>
                      </div>
                    </form>
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
import { computed, ref } from "vue"
import { AppState } from "../AppState"
import { ingredientsService } from "../services/IngredientsService"
import { stepsService } from "../services/StepsService"

export default {
  setup() {
    let recipe = computed(() => AppState.activeRecipe)
    let steps = computed(() => AppState.activeRecipeSteps)
    let ingredients = computed(() => AppState.activeRecipeIngredients)
    let account = computed(() => AppState.account)
    let stepData = ref({})
    let ingredientData = ref({})

    return {
      recipe,
      steps,
      ingredients,
      stepData,
      ingredientData,
      account,
      async createStep() {
        console.log(stepData.value);
        await stepsService.createStep(stepData.value, AppState.activeRecipe.id)
        document.getElementById("stepForm").reset()
        stepData.position = 0
        stepData.body = ""
      },
      async createIngredient() {
        console.log(ingredientData.value);
        await ingredientsService.createIngredient(ingredientData.value, AppState.activeRecipe.id)
        ingredientData.name = ""
        ingredientData.quantity = ""
        document.getElementById("ingredientForm").reset()
      }
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

.form-input {}
</style>

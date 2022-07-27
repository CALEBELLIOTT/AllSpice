
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
              <div class="col-12">
                <div class="d-flex flex-column align-items-center">
                  <h1><i class=" like-btn mdi mdi-heart text-secondary m-0" :id="`like-btn-${random}`"
                      @click="toggleFavorite()"></i>
                  </h1>
                  <p class="text-muted">Favorite this recipe!</p>
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
    let favorites = computed(() => AppState.accountFavorites)
    let random = Math.random(10000);

    return {
      recipe,
      steps,
      ingredients,
      stepData,
      ingredientData,
      account,
      favorites,
      random,
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
      },
      async toggleFavorite() {
        let target = document.getElementById(`like-btn-${random}`)
        console.log(target);
        let liked = false
        target.classList.forEach(c => {
          console.log(c);
          if (c == "text-primary") {
            liked = true
          }
        })
        if (liked) {
          target.classList.remove("text-primary")
          target.classList.add("text-secondary")
        }
        if (!liked) {
          console.log("not liked ");
          target.classList.remove("text-secondary")
          target.classList.add("text-primary")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-img {
  min-height: 70vh;
  background-size: cover;
  background-position: center;
}

.recipe-card {
  box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
  max-height: 40vh;
  overflow-y: scroll;
}

.form-input {}

.like-btn {
  font-size: 4rem;
}

.like-btn:hover {
  text-shadow: 0 0 3px #527360;
  cursor: pointer;
}

.like-btn.liked {
  color: #c6383a;
}
</style>

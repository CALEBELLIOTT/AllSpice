
<template>
  <!-- Button trigger modal -->
  <button type="button" class="btn btn-secondary rounded-pill create-recipe-btn" data-bs-toggle="modal"
    data-bs-target="#createRecipeModal">
    <h3 class="m-0"><i class="mdi mdi-plus"></i></h3>
  </button>

  <!-- Modal -->
  <div class="modal fade" id="createRecipeModal" tabindex="-1" aria-labelledby="createRecipeModal" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body p-0">
          <h3 class="text-light bg-secondary p-2">Share A New Recipe</h3>
          <form action="" @submit.prevent="submitRecipe()" id="createRecipeForm">
            <div class="row">
              <div class="col-md-6">
                <div class="p-2">
                  <label for="">Recipe Title</label>
                  <input type="text" placeholder="Title..." class="form-control" v-model="recipeData.title">
                </div>
              </div>
              <div class="col-md-6">
                <div class="p-2">
                  <label for="">Recipe Category</label>
                  <input type="text" placeholder="Category..." class="form-control" v-model="recipeData.category">
                </div>
              </div>
              <div class="col-12">
                <div class="p-2">
                  <label for="">Recipe Image</label>
                  <input type="text" placeholder="image Url..." class="form-control" v-model="recipeData.picture">
                </div>
              </div>
              <div class="col-12">
                <div class="p-2">
                  <label for="">Recipe Subtitle</label>
                  <textarea name="" id="" cols="30" rows="3" placeholder="Subtitle..." class="form-control"
                    v-model="recipeData.subTitle"></textarea>
                  <p class="text-muted">Add a brief description of the recipe</p>
                </div>
              </div>
              <div class="col-12 d-flex justify-content-end">
                <button class="btn btn-secondary m-2" type="submit" data-bs-dismiss="modal"><i
                    class="mdi mdi-send"></i></button>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService";

export default {
  setup() {
    let recipeData = ref({})
    return {
      recipeData,
      async submitRecipe() {
        console.log(recipeData.value);
        await recipesService.createRecipe(recipeData.value)
        document.getElementById("createRecipeForm").reset()
        recipeData.title = ""
        recipeData.subTitle = ""
        recipeData.picture = ""
        recipeData.category = ""
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.create-recipe-btn {
  position: fixed;
  left: 95vw;
  bottom: 3vh;
}
</style>

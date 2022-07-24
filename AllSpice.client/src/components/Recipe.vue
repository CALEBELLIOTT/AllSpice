<template>
  <div class="row">
    <div class="col-12 p-2">
      <div class="recipe-card border border-secondary d-flex flex-column justify-content-between"
        :style="`background-image: url(${recipe.picture});`">
        <div class="d-flex justify-content-between">
          <p class="category-text p-1">{{ recipe.category }}</p>
          <p class="category-text p-1 text-secondary like-btn"><i class="mdi mdi-heart"></i></p>
        </div>
        <div>
          <p class="category-text m-0">{{ recipe.title }}</p>
          <p class="muted-background m-0">{{ recipe.subtitle }}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: { recipe: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.recipe-card {
  height: 15rem;
  width: 15rem;
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
  border-radius: 2px;
}

.category-text {
  backdrop-filter: blur(2px);
  font-size: 1.5rem;
  background-color: rgba(226, 226, 226, 0.543);
  border-radius: 2px;
}

.like-btn:hover {
  text-shadow: 0 0 2px #527360;
  cursor: pointer;
}

.muted-background {
  background-color: rgba(226, 226, 226, 0.543);
  backdrop-filter: blur(2px);
}
</style>

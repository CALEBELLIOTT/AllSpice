<template>
  <div class="row">
    <div class="col-12 p-2">
      <div class="recipe-card" :style="`background-image: url(${recipe.picture});`">
        <div class="d-flex justify-content-between">
          <p class="category-text p-1">{{ recipe.category }}</p>
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
}

.category-text {
  backdrop-filter: blur(2px);
  font-size: 1.5rem;
  background-color: rgba(226, 226, 226, 0.543);
  border-radius: 2px;
}
</style>

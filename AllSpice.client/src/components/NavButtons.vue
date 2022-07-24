<template>
  <div class="row">
    <div class="col-12">
      <div class="nav-container text-secondary bg-light p-2 d-flex justify-content-between">
        <h5 class="m-0 ms-1 nav-item" @click="pageNav('')">Home</h5>
        <h5 class="m-0 nav-item" @click="pageNav('MyRecipes')">My Recipes</h5>
        <h5 class="m-0 me-1 nav-item" @click="pageNav('About')">Favorites</h5>
      </div>
    </div>
  </div>
</template>


<script>
import { router } from "../router"

export default {
  setup() {
    return {
      pageNav(location) {
        console.log(location);
        router.push(location)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.nav-container {
  width: 30vw;
  // border: 2px solid #c6383a;
  border: 2px solid #527360;
  ;
  border-radius: 2px;
  transform: translateY(-1.5rem);
}

.nav-item:hover {
  cursor: pointer;
}


@media(max-width: 830px) {
  .nav-container {
    width: 80vw;
  }
}
</style>
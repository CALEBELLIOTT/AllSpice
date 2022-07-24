
<template>
  <div class="row">
    <div class="col-12 m-0 p-0">
      <div class="hero-banner border-bottom border-primary border-top">
        <div class="row">
          <div class="col-12 d-flex justify-content-end">
            <login></login>
          </div>
          <div class="col-12 d-flex justify-content-end">
            <div class="text-container">
              <h1 class="mb-3">AllSpice</h1>
              <h5 class="mx-2">We Connect You With Recipes</h5>
              <h5 class="mx-5">So You Can Connect With Loved Ones</h5>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.hero-banner {
  background-image: url(../assets/img/brooke-lark-08bOYnH_r_E-unsplash.jpg);
  height: 50vh;
  background-size: cover;
  background-repeat: no-repeat;
}

.text-container {
  width: 50vw;
}
</style>

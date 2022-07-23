<template>
  <main>
    <router-view />
  </main>
  <footer>
  </footer>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import { recipesService } from "./services/RecipesService"
export default {
  name: 'App',
  setup() {
    onMounted(async () => {
      await recipesService.getAll()
    })
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>

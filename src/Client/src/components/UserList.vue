<script setup lang="ts">
defineProps({
  users: Array,
})
</script>

<template>
  <ul>
    <li v-for="user in users" :key="user.id">
      {{ user.name }}: {{ user.email }}
    </li>
  </ul>
</template>

<style scoped>

</style>
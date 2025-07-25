<script setup>
import { ref, onMounted } from 'vue'
import UserTable from '@/components/UserTable.vue'  // путь подставь свой

const users = ref([])
const loading = ref(false)
const error = ref(null)

onMounted(async () => {
  loading.value = true
  try {
    const res = await fetch('/api/users')
    if (!res.ok) throw new Error('Ошибка загрузки пользователей')
    const data = await res.json()
    users.value = data.users || data
  } catch (err) {
    error.value = err
  } finally {
    loading.value = false
  }
})
</script>

<template>
  <v-container>
    <UserTable :users="users" :loading="loading" :error="error" />
  </v-container>
</template>

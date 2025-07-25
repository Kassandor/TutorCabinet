<script setup>
defineProps({
  users: {
    type: Array,
    default: () => []
  },
  loading: {
    type: Boolean,
    default: false
  },
  error: {
    type: Object,
    default: null
  }
})
</script>

<template>
  <div>
    <v-alert type="error" v-if="error" class="mb-4">
      {{ error.message }}
    </v-alert>

    <v-data-table
      :headers="[
        { text: 'Имя', value: 'name' },
        { text: 'Email', value: 'email' }
      ]"
      :items="users"
      :loading="loading"
      loading-text="Загрузка пользователей..."
      class="elevation-1"
      :items-per-page="5"
    >
      <template #top>
        <v-toolbar flat>
          <v-toolbar-title>Пользователи</v-toolbar-title>
        </v-toolbar>
      </template>
    </v-data-table>
  </div>
</template>

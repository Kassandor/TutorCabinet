<script setup lang="ts">
import {ref, onMounted} from "vue";
import UserList from "@/components/UserList.vue";

const users = ref([]);
const loading = ref(false);
const error = ref(null);

async function fetchUsers() {
  loading.value = true;
  error.value = null;
  try {
    const res = await fetch("/api/users");
    if (!res.ok) throw new Error("Failed to fetch users");
    users.value = await res.json();
  } catch (error) {
    error.value = error;
  } finally {
    loading.value = false;
  }
}

onMounted(fetchUsers);
</script>

<template>
  <div>
    <UserList :users="users.users"/>
    <p v-if="loading">Loading...</p>
    <p v-if="error">{{ error }}</p>
  </div>
</template>

<style scoped>

</style>
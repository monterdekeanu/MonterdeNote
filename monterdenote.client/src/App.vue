<template>
  <div class="common-layout">
    <el-container>
      <el-aside width="200px"></el-aside>
      <el-main><RouterView /></el-main>
      <el-aside width="200px"></el-aside>
    </el-container>
  </div>
</template>
<script setup>
import { RouterView } from 'vue-router'
</script>

<style scoped></style>

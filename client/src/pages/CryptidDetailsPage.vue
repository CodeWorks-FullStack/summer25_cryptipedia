<script setup>
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

onMounted(getCryptidById)

async function getCryptidById() {
  try {
    await cryptidsService.getCryptidById(route.params.cryptidId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET CRYPTID', error)
  }
}

</script>


<template>
  sup!
</template>


<style lang="scss" scoped></style>
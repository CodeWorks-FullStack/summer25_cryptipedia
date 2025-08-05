<script setup>
import { AppState } from '@/AppState.js';
import { cryptidEncountersService } from '@/services/CryptidEncountersService.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const cryptid = computed(() => AppState.cryptid)

const route = useRoute()

onMounted(() => {
  getCryptidById()
  getCryptidEncounterProfilesByCryptidId()
})

async function getCryptidById() {
  try {
    await cryptidsService.getCryptidById(route.params.cryptidId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET CRYPTID', error)
  }
}

async function getCryptidEncounterProfilesByCryptidId() {
  try {
    await cryptidEncountersService.getCryptidEncounterProfilesByCryptidId(route.params.cryptidId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET PROFILES', error)
  }
}

</script>


<template>
  <div v-if="cryptid" class="container-fluid">
    <div class="row">
      <div class="col-md-7">
        <div class="italiana-font p-3">
          <h2 class="text-warning text-capitalize">{{ cryptid.origin }} Cryptid</h2>
          <h1>{{ cryptid.name }}</h1>
          <p class="fs-4 mb-3">Discovered by {{ cryptid.discoverer.name }}</p>
          <p class="ibm-plex-mono-font">
            {{ cryptid.description }}
          </p>
          <div>
            <span class="fs-1">Size</span>
            <div :title="`The size of ${cryptid.name} is ${cryptid.size}/10`">
              <span v-for="i in 10" :key="'cryptid-size-' + i" class="mdi fs-1"
                :class="i <= cryptid.size ? 'mdi-circle' : 'mdi-circle-outline'"></span>
            </div>
          </div>
          <div :class="{ 'text-danger': cryptid.threatLevel == 10 }">
            <span class="fs-1">Threat Level</span>
            <div :title="`The threat level of ${cryptid.name} is ${cryptid.threatLevel}/10`">
              <span v-for="i in 10" :key="'cryptid-threat-level-' + i" class="mdi fs-1"
                :class="i <= cryptid.threatLevel ? 'mdi-circle' : 'mdi-circle-outline'"></span>
            </div>
          </div>
          <div>
            <span class="fs-1 text-warning">Encountered By {{ cryptid.encounterCount }} Humans</span>
          </div>
        </div>
      </div>
      <div class="col-md-5 px-3 px-md-0">
        <div class="cryptid-picture-section">
          <img :src="cryptid.imgUrl" :alt="`Definitive proof of the ${cryptid.name} in their natural habitat`"
            class="cryptid-img">
        </div>
      </div>
    </div>
  </div>
  <div v-else class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="p-3">
          <h1 class="italiana-font">Loading... <span class="mdi mdi-ufo mdi-spin"></span></h1>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
h1 {
  font-size: 7rem;
}

.cryptid-img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  filter: blur(3px) grayscale(20%);
}

.cryptid-picture-section {
  overflow: hidden;
}
</style>
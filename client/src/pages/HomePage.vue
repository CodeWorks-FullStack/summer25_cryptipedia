<script setup>
import { AppState } from '@/AppState.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const cryptids = computed(() => AppState.cryptids)

onMounted(getCryptids)

async function getCryptids() {
  try {
    await cryptidsService.getCryptids()
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET CRYPTIDS', error)
  }
}

</script>

<template>
  <section class="forest-bg">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-8 align-self-center">
          <div class="px-4">
            <h2 class="italiana-font fs-1">Terrestrials</h2>
            <p>
              A terrestrial cryptid is a creature that exists on land but has not been “scientifically” proven. These
              creatures often stem from folklore, mythology, or anecdotal evidence. Unlike aquatic cryptids, like the
              Loch
              Ness Monster, terrestrial cryptids inhabit forests, mountains, or other land-based environments.
            </p>
            <p>Examples of Terrestrials: El Chupacabra, Jackelope</p>
          </div>
        </div>
        <div class="col-md-4 align-self-end">
          <img src="https://www.pumpkin.care/wp-content/uploads/2022/07/04_pet_portraits_nena.png"
            alt="Cryptid licking her lips" class="img-fluid">
        </div>
      </div>
    </div>
  </section>
  <section>
    <div class="container">
      <div class="row">
        <div class="col-12">
          <h1 class="italiana-font display-1 my-5">Cryptids</h1>
        </div>
        <div v-for="cryptid in cryptids" :key="'cryptid-list-' + cryptid.id" class="col-md-3">
          {{ cryptid.name }}
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.forest-bg {
  background-image: url(https://images.unsplash.com/photo-1446553009413-64b9505cacb0?q=80&w=1740&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
  background-position: bottom;
  text-shadow: 1px 2px 5px black;

  .container-fluid {
    backdrop-filter: blur(2px) grayscale(70%);
    background-color: rgba(0, 0, 0, 0.758);
  }

  .row {
    min-height: 80dvh;
  }

  img {
    filter: hue-rotate(114deg);
  }
}
</style>

<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <div class="position-relative shadow ibm-plex-mono-font">
    <img :src="cryptid.imgUrl" :alt="'a blurry picture of the ' + cryptid.name">
    <div class="encounter-info mx-2">
      <span class="mdi mdi-ufo"></span>
      0
    </div>
    <div class="cryptid-info p-2">
      <span v-if="cryptid.id < 10">0</span>{{ cryptid.id }}
      <hr>
      <span>{{ cryptid.name }}</span>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.position-relative {
  overflow: hidden;
  font-size: 1.3rem;
  text-shadow: 1px 2px 5px black;
}

img {
  width: 100%;
  height: 500px;
  object-fit: cover;
  filter: blur(3px) grayscale(30%);
}

.encounter-info {
  position: absolute;
  right: 0;
  top: 0;
}

.cryptid-info {
  position: absolute;
  bottom: 0;
  width: 100%;
}
</style>
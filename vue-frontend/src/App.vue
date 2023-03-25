<template>
  <div id="app">
    <DeviceList />
    <EnergyUsageList />
  </div>
</template>

<script>
import DeviceList from './components/DeviceList.vue';
import EnergyUsageList from './components/EnergyUsageList.vue';

export default {
  components: {
    DeviceList,
    EnergyUsageList,
  },
};
</script>

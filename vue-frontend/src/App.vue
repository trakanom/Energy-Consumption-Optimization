<template>
  <div id="app">
    <h1>My Device Manager</h1>
    <button @click="showDeviceForm">Add Device</button>
    <button @click="showEditForm">Edit Device</button>
    <button @click="deleteDevice">Delete Device</button>
    <DeviceList :devices="devices" />
    <DeviceForm v-if="showForm" @submit="addDevice" @cancel="cancelForm" />
    <DeviceForm v-if="showEdit" :device="selectedDevice" @submit="updateDevice" @cancel="cancelForm" />
  </div>
</template>

<script>
import DeviceList from "./components/DeviceList.vue";
import DeviceForm from "./components/DeviceForm.vue";
import axios from "axios";
import { apiUrl } from "./api";


export default {
  name: "App",
  components: {
    DeviceList,
    DeviceForm,
  },
  data() {
    return {
      devices: [],
      showForm: false,
      showEdit: false,
      selectedDevice: null,
    };
  },
  created() {
    this.fetchDevices();
  },
  methods: {
    async fetchDevices() {
      try {
        const response = await axios.get(`${apiUrl}/devices`);
        this.devices = response.data;
      } catch (error) {
        console.error("Error fetching devices:", error);
      }
    },
    showDeviceForm() {
      this.showForm = true;
      this.showEdit = false;
      this.selectedDevice = null;
    },
    showEditForm() {
      this.showForm = false;
      this.showEdit = true;
    },
    async addDevice(device) {
      try {
        const response = await axios.post(
          `${apiUrl}/devices`,
          device
        );
        this.devices.push(response.data);
        this.cancelForm();
      } catch (error) {
        console.error("Error adding device:", error);
      }
    },
    async updateDevice(device) {
      try {
        const response = await axios.put(
          `${apiUrl}/devices/${device.id}`,
          device
        );
        const index = this.devices.findIndex(
          (d) => d.id === response.data.id
        );
        this.devices.splice(index, 1, response.data);
        this.cancelForm();
      } catch (error) {
        console.error("Error updating device:", error);
      }
    },
    async deleteDevice() {
      try {
        await axios.delete(
          `${apiUrl}/devices/${this.selectedDevice.id}`
        );
        this.devices = this.devices.filter(
          (d) => d.id !== this.selectedDevice.id
        );
        this.cancelForm();
      } catch (error) {
        console.error("Error deleting device:", error);
      }
    },
    cancelForm() {
      this.showForm = false;
      this.showEdit = false;
      this.selectedDevice = null;
    },
  },
};
</script>

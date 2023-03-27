
<template>
    <form @submit.prevent="submitForm">
        <div>
            <label for="device-name">Name</label>
            <input id="device-name" v-model="localDevice.name" type="text" required />
        </div>
        <div>
            <label for="device-type">Type</label>
            <input id="device-type" v-model="localDevice.type" type="text" required />
        </div>
        <div>
            <label for="device-power-consumption">Power Consumption (W)</label>
            <input id="device-power-consumption" v-model="localDevice.powerConsumption" type="number" required />
        </div>
        <button type="submit">Submit</button>
    </form>
</template>

data() {
    return {
      localDevice: {
        id: this.localDevice.id,
        name: this.localDevice.name,
        type: this.localDevice.type,
        powerConsumption: this.localDevice.powerConsumption,
      },
    };
  },
  
<script>
import axios from 'axios';
import { apiUrl } from '@/api';

// Use apiUrl as the base URL for your API calls
axios.get(`${apiUrl}/devices`)
    .then(response => {
        console.log(response.data);
    })
    .catch(error => {
        console.error(error);
    });

export default {

    props: {
        device: {
            type: Object,
            required: true,
        },
    },
    methods: {

        async submitForm() {
            try {
                let response;
                if (this.device.id) {
                    response = await axios.put(`${apiUrl}/devices/${this.device.id}`, this.device);
                } else {
                    response = await axios.post(`${apiUrl}/devices`, this.device);
                }
                this.$emit('submit', response.data);
            } catch (error) {
                console.error('Error submitting form:', error);
            }
        },
        editDevice(device) {
            this.selectedDevice = { ...device };
            this.formVisible = true;
        },

        async updateDevice(updatedDevice) {
            const index = this.devices.findIndex(device => device.id === updatedDevice.id);
            if (index !== -1) {
                this.devices.splice(index, 1, updatedDevice);
            } else {
                this.devices.push(updatedDevice);
            }
            this.closeForm();
        },

        async deleteDevice(deviceId) {
            try {
                await axios.delete(`${apiUrl}/devices/${deviceId}`);
                this.devices = this.devices.filter(device => device.id !== deviceId);
            } catch (error) {
                console.error('Error deleting device:', error);
            }
        },
    },
};
</script>
  
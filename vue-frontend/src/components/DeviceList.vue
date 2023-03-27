<template>
    <div>
        <h1>Device List</h1>
        <button @click="showForm">Add Device</button>

        <ul>
            <li v-for="device in devices" :key="device.id">
                <DeviceCard :device="device" />
                <button @click="editDevice(device)">Edit</button>
                <button @click="deleteDevice(device.id)">Delete</button>
            </li>
        </ul>

        <DeviceForm v-if="formVisible" :device="selectedDevice" @submit="updateDevice($event)" @cancel="closeForm" />
    </div>
</template>

<script>
import DeviceForm from './DeviceForm.vue';
import DeviceCard from './DeviceCard.vue';
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
    name: 'DeviceList',
    components: {
        DeviceForm,
        DeviceCard,
    },
    data() {
        return {
            devices: [], // You can add dummy data or fetch real data from your API
            formVisible: false,
            selectedDevice: null,
        };
    },
    methods: {
        async fetchDevices() {
            try {
                const response = await axios.get(`${apiUrl}/devices`);
                this.devices = response.data;
            } catch (error) {
                console.error('Error fetching devices:', error);
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
        showForm() {
            this.selectedDevice = null; // Clear the selected device
            this.formVisible = true;
        },
        closeForm() {
            this.formVisible = false;
        },
        async addDevice(device) {
            try {
                const response = await axios.post(`${apiUrl}/devices`, device);
                this.devices.push(response.data);
                this.closeForm();
            } catch (error) {
                console.error('Error adding device:', error);
            }
        }
    },
    created() {
        this.fetchDevices();
    }
};

</script>

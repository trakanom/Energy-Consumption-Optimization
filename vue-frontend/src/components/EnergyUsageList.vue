<template>
    <div>
        <h1>Energy Usage</h1>
        <ul>
            <li v-for="usage in energyUsage" :key="usage.id">
                {{ usage.deviceId }} - {{ usage.dateTime }} - {{ usage.energyConsumed }}kWh
            </li>
        </ul>
    </div>
</template >

<script>
import axios from 'axios';
axios.get(`${apiUrl}/devices`)
    .then(response => {
        console.log(response.data);
    })
    .catch(error => {
        console.error(error);
    });



export default {
    data() {
        return {
            energyUsage: [],
        };
    },
    async created() {
        try {
            const response = await axios.get(`${apiUrl}/energyusage`); //replace the url with the right port and endpoint
            this.energyUsage = response.data;
        } catch (error) {
            console.error('Error fetching energy usage:', error);
        }
    },
};
</script>

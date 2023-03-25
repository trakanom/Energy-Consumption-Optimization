<template>
    <div>
        <!-- Display the device details here -->
        <p>{{ device.name }}</p>
        <p>{{ device.type }}</p>
        <!-- Add more properties as needed -->
    </div>
</template>
  
<script>
export default {
    props: {
        device: {
            type: Object,
            required: true,
        },
    },
};
</script>
  
<style scoped>
/* Add styles for the DeviceCard component if needed */
</style>
  
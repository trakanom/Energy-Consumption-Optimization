const express = require('express');
const cors = require('cors');
const app = express();
const port = 5069;

app.use(cors()); //cors middleware

app.get('/api/devices', (req, res) => {
    const devices = [
        { id: 1, name: 'Device 1' },
        { id: 2, name: 'Device 2' },
        { id: 3, name: 'Device 3' },
    ];

    res.json(devices);
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});

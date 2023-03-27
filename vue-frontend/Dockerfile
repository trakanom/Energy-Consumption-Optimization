# Use the official Node.js image as the base image
FROM node:14

# Set the working directory
WORKDIR /vue-frontend

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install the dependencies
RUN npm install

# Copy the rest of the frontend source code
COPY . .

# Expose the port the app will run on
EXPOSE 8080

# Run the app
CMD ["npm", "run", "serve"]

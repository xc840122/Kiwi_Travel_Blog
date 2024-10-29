/**
 * api utility
 * Centrilize the management of api
 */
// src/utils/api.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5082/api', // Adjust the base URL as needed
});

// Paths to exclude from adding JWT token
const authExcludedRoutes = ['/register', '/login'];

api.interceptors.request.use(
  (config) => {
    // Check if the request URL path matches any of the excluded routes
    const isExcluded = authExcludedRoutes.some((route) => config.url.includes(route));

    // If not excluded, add the Authorization header with JWT token
    if (!isExcluded) {
      const token = localStorage.getItem('token');
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }
    } else {
      console.info(`Excluding Authorization header for route: ${config.url}`);
    }

    return config;
  },
  (error) => {
    console.error("Request error:", error);
    return Promise.reject(error);
  }
);

export default api;
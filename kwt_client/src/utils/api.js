import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5082/api',
});

// intercept request, add token to all requests except login and registration
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default api;
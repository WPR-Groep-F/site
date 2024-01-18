import axios from 'axios';

const axiosInstance = axios.create();

axiosInstance.interceptors.request.use(
    (config) => {
        const tokenObject = JSON.parse(localStorage.getItem('token'));

        if (tokenObject && tokenObject.token) {
            config.headers['Authorization'] = `Bearer ${tokenObject.token}`;
        }

        return config;
    },

    (error) => {
        return Promise.reject(error);
    }
);

export default axiosInstance;
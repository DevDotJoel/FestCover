import Axios, { InternalAxiosRequestConfig } from "axios";

import { toast } from "react-toastify";
import { API_URL } from "../config/env";
import { refreshToken } from "../features/auth/api/refreshToken";

export const api = Axios.create({
  baseURL: API_URL,
});
api.defaults.withCredentials = true;
api.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    const accessToken = localStorage.getItem("accessToken");
    if (accessToken) {
      config.headers["Authorization"] = "Bearer " + accessToken;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);
api.interceptors.response.use(
  (response) => {
    return response.data;
  },
  async (error) => {
    const message = error.response?.data?.title;
    const originalRequest = error?.config;
    console.log(error.response?.status)
    if (error.response?.status == 401) {
      try {
        const accessToken = localStorage.getItem("accessToken");
        if (accessToken != null) {
          const response = await refreshToken({ accessToken: accessToken });
          console.log(response);
          localStorage.setItem("accessToken", response.accessToken);
          originalRequest.headers["Authorization"] =
            "Bearer " + response.accessToken;
          originalRequest._retry = true;
          return originalRequest;
        }
      } catch (error) {
        localStorage.removeItem("accessToken");
        window.location.href = `/auth/login`;
      }

      // window.location.href = `/auth/login`;
    }

    return Promise.reject(error);
  }
);

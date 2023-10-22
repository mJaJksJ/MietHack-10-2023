import { AxiosInstance, AxiosRequestConfig, AxiosRequestHeaders, InternalAxiosRequestConfig } from "axios";
import { LOCAL_STORAGE_TOKEN } from "./localStorage.consts";

/**
 * Non-automatically add to api.ts
 * Need add in api.ts in constuctor line 'addInterceptor(this.instance);' after line 'this.instance = instance ? instance : axios.create();'
 */
export const addInterceptor = (instance: AxiosInstance) => {
    instance.interceptors.request.use((config: InternalAxiosRequestConfig) => {
        config.headers = { ...config.headers, Authorization: `Bearer ${localStorage.getItem(LOCAL_STORAGE_TOKEN)}` } as AxiosRequestHeaders
        return config;
    }, function (error: any) {
        return Promise.reject(error);
    });
}
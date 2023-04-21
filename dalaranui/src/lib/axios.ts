import Axios, { AxiosRequestConfig, InternalAxiosRequestConfig } from 'axios';

import { API_URL } from '@/config';
import { storage } from '@/utils/storage';

const authRequestInterceptor = (config: AxiosRequestConfig) => {
  config.headers = config.headers ?? {};
  const token = storage.getToken();
  if (token) {
    config.headers.Authorization = `${token}`;
  }
  config.headers.Accept = 'application/json';
  return config;
};

export const axios = Axios.create({
  baseURL: API_URL,
});

axios.interceptors.request.use(async(config: InternalAxiosRequestConfig));

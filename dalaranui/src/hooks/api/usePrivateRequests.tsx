import { AxiosHeaders, AxiosRequestConfig } from 'axios';
import { useState } from 'react';
import axios from '../../api/axios';

export type PrivateRequestParams = {
  requestType?: 'GET' | 'POST' | 'PUT' | 'DELETE';
  url: string;
  payload?: object;
  config: AxiosRequestConfig;
};

const usePrivateRequests = (props: PrivateRequestParams) => {
  const { requestType, url, payload, config } = props;
  const [data, setData] = useState<unknown>();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const getRequest = async () => {
    setIsLoading(true);
    try {
      const response = await axios.get(url, config);
      setData(response);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };
};

export default usePrivateRequests;

import { useState } from 'react';
import { axiosPrivate } from '../../api/axios';

type UseGetRequestParams = {
  url: string;
};

const useRequests = () => {
  const [data, setData] = useState<unknown>();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const getRequest = (params: UseGetRequestParams) => {
    const { url } = params;
  };

  return { useGetRequest };
};

export default useRequests;

import {  isAuthResponse, useAuth } from '@/features/auth';
import { axios } from '@/lib/axios';
import { useState } from 'react';
import { AxiosError, isAxiosError } from 'axios';

type CreateBajAccountRequest = {
  newcomerBajProfileName: string;
};

type CreateBajAccountStatus = 'Success' | 'Username taken' | 'Server error occurred';

export const useNewcomerBajs = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [status, setStatus] = useState<CreateBajAccountStatus>();
  const authContext = useAuth();
  if (!authContext) {
    throw new Error('Auth context undefined or null');
  }
  const { updateAuth } = authContext;

  const registerNewBaj = async (request: CreateBajAccountRequest) => {
    setIsLoading(true);
    try {
      const response = await axios.post(
        'newcomerbaj/register',
        JSON.stringify(request)
      );
      if (isAuthResponse(response)) {
        setStatus('Success');
        updateAuth(response);
      } else {
        return Promise.reject(new Error('Invalid data format returned'));
      }
    } catch (error) {
      if (isAxiosError(error)) {
        if (error?.response?.status === 409) {
          setStatus('Username taken');
        } else {
          setStatus('Server error occurred')
        }
      }
    } finally {
      setIsLoading(false);
    }
  };

  return { status, isLoading, registerNewBaj };
};

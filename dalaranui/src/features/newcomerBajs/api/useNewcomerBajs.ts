import { AuthStateType, isAuthResponse } from '@/features/auth';
import { axios } from '@/lib/axios';
import { useState } from 'react';
import { AxiosError } from 'axios';

type CreateBajAccountRequest = {
  newcomerBajProfileName: string;
};

type CreateBajAccountStatus = 'Success' | 'Username taken';

export const useNewcomerBajs = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [status, setStatus] = useState<CreateBajAccountStatus>();

  const registerNewBaj = async (
    request: CreateBajAccountRequest
  ): Promise<AuthStateType> => {
    setIsLoading(true);
    try {
      const response = await axios.post(
        'newcomerbaj/register',
        JSON.stringify(request)
      );
      if (isAuthResponse(response)) {
        setStatus('Success');
        return response;
      } else {
        return Promise.reject(new Error('Invalid data format returned'));
      }
    } catch (error) {
      if ((error as AxiosError).response?.data === 'Username already taken') {
        setStatus('Username taken');
      }
      return Promise.reject(error);
    } finally {
      setIsLoading(false);
    }
  };

  return { status, isLoading, registerNewBaj };
};

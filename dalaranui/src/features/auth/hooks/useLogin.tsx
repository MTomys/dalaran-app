import { useState } from 'react';
import { isAxiosError } from 'axios';

import { useAuth } from './useAuth';
import { axios } from '@/lib/axios';
import { AuthStateType } from '@/features/auth/index';

const INVALID_USAGE_MESSAGE =
  'Error while using useLogin, useAuth context should never be null or undefined when calling this hook';

export type LoginRequestType = {
  username: string;
  password: string;
};

export type LoginStatusType = 'Success' | 'InvalidCredentials' | 'ServerError';

export const useLogin = () => {
  const authContext = useAuth();
  if (authContext === null || authContext === undefined) {
    throw new Error(INVALID_USAGE_MESSAGE);
  }

  const { updateAuth } = authContext;
  const [isLoading, setIsLoading] = useState(false);
  const [loginStatus, setLoginStatus] = useState<LoginStatusType>();

  const login = async (loginRequest: LoginRequestType) => {
    setIsLoading(true);
    try {
      const response = await axios.post(
        'auth/login',
        JSON.stringify(loginRequest)
      );
      if (isAuthResponse(response)) {
        updateAuth(response);
        setLoginStatus('Success');
      }
    } catch (error) {
      if (isAxiosError(error)) {
        if (error?.response?.status === 403) {
          setLoginStatus('InvalidCredentials');
        }
      }
    }
    setIsLoading(false);
  };

  return { isLoading, login, loginStatus };
};

const isAuthResponse = (object: unknown): object is AuthStateType => {
  if (object !== null && typeof object === 'object') {
    return 'token' in object;
  }
  return false;
};

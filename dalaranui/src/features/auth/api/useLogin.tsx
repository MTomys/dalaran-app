import { useState } from 'react';

import { useAuth } from './useAuth';
import { axios } from '@/lib/axios';
import { isAuthResponse } from '@/features/auth';
import { isAxiosErrorResponse } from '@/index';

const INVALID_USAGE_MESSAGE =
  'Error while using useLogin, useAuth context should never be null or undefined when calling this hook';

export type LoginRequestType = {
  username: string;
  password: string;
};

export type LoginStatusType =
  | 'Login successful'
  | 'Invalid credentials'
  | 'An error occurred';

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
      const response = await axios.post('auth/login', JSON.stringify(loginRequest));
      if (isAuthResponse(response)) {
        updateAuth(response);
        setLoginStatus('Login successful');
      }
    } catch (error) {
      if (isAxiosErrorResponse(error)){
        console.log('axios error response found:', error)
      }
    }
    setIsLoading(false);
  };

  return { isLoading, login, loginStatus };
};

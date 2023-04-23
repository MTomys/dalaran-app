import { useAuth } from './useAuth';
import { useState } from 'react';

import { axios } from '@/lib/axios';
import { AuthStateType } from '@/features/auth/index';

const INVALID_USAGE_MESSAGE =
  'Error while using useLogin, useAuth context should never be null or undefined when calling this hook';

export type LoginRequestType = {
  username: string;
  password: string;
};

export const useLogin = () => {
  const authContext = useAuth();
  if (authContext === null || authContext === undefined) {
    throw new Error(INVALID_USAGE_MESSAGE);
  }

  const { updateAuth } = authContext;
  const [isLoading, setIsLoading] = useState(false);
  const [isSuccess, setIsSuccess] = useState(false);

  const login = async (loginRequest: LoginRequestType) => {
    setIsLoading(true);
    const response = await axios.post('/login', JSON.stringify(loginRequest));
    if (isAuthResponse(response)) {
      updateAuth(response);
      setIsSuccess(true);
    }
    setIsLoading(false);
  };

  return { isLoading, login, isSuccess };
};

const isAuthResponse = (object: unknown): object is AuthStateType => {
  if (object !== null && typeof object === 'object') {
    return 'token' in object;
  }
  return false;
};

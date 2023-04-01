import useAuth from './useAuth';
import axios from '../../api/axios';
import { useState } from 'react';
import { AuthStateType } from '../../context/Auth/AuthProvider';

const INVALID_USAGE_MESSAGE =
  'Error while using useLogin, useAuth context should never be null when calling this hook';

export type LoginOptions = {
  url: string;
  payload: {
    username: string;
    password: string;
    requestPhrase?: string;
  };
};

const useLogin = (options: LoginOptions) => {
  const { url, payload } = options;
  const { auth, updateAuth, clearAuth } = useAuth()!;
};

export default useLogin;

import { axios } from '@/lib/axios';
import { AuthStateType } from '@/features/auth';
import { useMutation } from '@tanstack/react-query';

export type LoginParams = {
  username: string;
  password: string;
};

const loginWithEmailAndPassword = async (
  params: LoginParams
): Promise<AuthStateType> => {
  return (await axios.post<AuthStateType>('/auth/login', params)).data;
};

export const useLogin = () => {
  return useMutation({
    mutationFn: (params: LoginParams) => loginWithEmailAndPassword(params),
  });
};

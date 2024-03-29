import { axios } from '@/lib/axios';
import { AuthResponseType } from '@/features/auth';
import { useMutation } from '@tanstack/react-query';

export type LoginParams = {
  username: string;
  password: string;
};

const loginWithEmailAndPassword = async (
  params: LoginParams
): Promise<AuthResponseType> => {
  return (await axios.post('/auth/login', params)).data;
};

export const useLogin = () => {
  return useMutation({
    mutationFn: (params: LoginParams) => loginWithEmailAndPassword(params),
  });
};

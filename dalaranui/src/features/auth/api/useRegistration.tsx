import { AuthResponseType } from '@/features/auth';
import { axios } from '@/lib/axios';
import { useMutation } from '@tanstack/react-query';

export type RegisterParams = {
  username: string;
  password: string;
};

const registerWithEmailAndPassword = async (
  params: RegisterParams
): Promise<AuthResponseType> => {
  return (await axios.post('/auth/login', params)).data;
};

export const useRegister = () => {
  return useMutation({
    mutationFn: (params: RegisterParams) => registerWithEmailAndPassword(params),
  });
};

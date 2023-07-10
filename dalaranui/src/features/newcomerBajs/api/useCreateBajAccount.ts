import { axios } from '@/lib/axios';
import { useMutation } from '@tanstack/react-query';

type CreateBajAccountRequest = {
  newcomerBajProfileName: string;
};

const requestBajAccount = async (request: CreateBajAccountRequest) => {
  await axios.post('newcomerbaj/register', JSON.stringify(request));
};

export const useCreateBajAccount = () => {
  return useMutation({
    mutationFn: (request: CreateBajAccountRequest) => requestBajAccount(request),
  });
};

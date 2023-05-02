import { AuthStateType } from '@/features/auth';
import { axios } from '@/lib/axios';

export type CreateBajAccountRequest = {
  newcomerBajProfileName: string;
}

export const useNewcomerBajs = () => {
  const registerNewBaj = (request: CreateBajAccountRequest): Promise<AuthStateType> => {
    return axios.post('newcomerbaj/register', request);
  }
}
import { axios } from '@/lib/axios';
import { useQuery } from '@tanstack/react-query';

export type PlebRequestResponse = {
  plebId: string;
  isAccepted: boolean;
  registrationRequest: {
    occurredAt: string;
    requestedUsername: string;
    requestedPassword: string;
    requestMessage: string;
  };
};

const getPlebRequests = async (): Promise<PlebRequestResponse[]> => {
  return (await axios.get('/admin/plebs')).data;
};

export const useGetPlebs = () => {
  return useQuery({
    queryKey: ['plebs'],
    queryFn: () => getPlebRequests(),
  });
};

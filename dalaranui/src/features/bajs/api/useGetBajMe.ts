import { axios } from '@/lib/axios';
import { BajMeResponse } from '@/features/bajs';
import { useQuery } from '@tanstack/react-query';

const getBajMe = async (): Promise<BajMeResponse> => {
  return (await axios.get('bajs/me')).data;
};

export const useGetBajMe = () => {
  return useQuery({
    queryKey: ['bajMe'],
    queryFn: getBajMe,
  });
};

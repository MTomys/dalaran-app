import { axios } from '@/lib/axios';
import { BajContactResponse } from '../types';
import { useQuery } from '@tanstack/react-query';

type GetBajContactsParams = {
  bajId: string;
};

const getBajContacts = async (
  params: GetBajContactsParams
): Promise<BajContactResponse[]> => {
  return (await axios.get(`bajs/${params.bajId}/contacts`)).data;
};

export const useGetBajContacts = (params: GetBajContactsParams) => {
  return useQuery({
    queryKey: [params.bajId, 'contacts'],
    queryFn: () => getBajContacts(params),
  });
};

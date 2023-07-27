import { axios } from '@/lib/axios';
import { BajContactResponse } from '../types';
import { useQuery } from '@tanstack/react-query';
import { config } from 'process';

type GetBajContactsParams = {
  bajId: string;
};

const getBajContacts = async (
  params: GetBajContactsParams
): Promise<BajContactResponse[]> => {
  return (
    await axios.get(`bajs/${params.bajId}/contacts`, {
      headers: {
        Authorization:
          'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0xMDAwMDAwMDAwMDEiLCJ1bmlxdWVfbmFtZSI6ImFkbWluIiwianRpIjoiMzYwNDljZjQtZmUzNS00ZWJhLWIyN2EtZTYyYmM0ZjJlMzU2IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJleHAiOjE2OTA0Nzg2MjEsImlzcyI6IkRhbGFyYW5BcHAiLCJhdWQiOiJEYWxhcmFuQXBwVXNlcnMifQ.vf4WmpH1dH7QN8Y1sBYQuXA4v_Y_aIyCUYt9mHxV8ss',
      },
    })
  ).data;
};

export const useGetBajContacts = (params: GetBajContactsParams) => {
  return useQuery({
    queryKey: [params.bajId, 'contacts'],
    queryFn: () => getBajContacts(params),
  });
};

import { axios } from '@/lib/axios';
import { ChatMessageResponse } from '../types';
import { useQuery } from '@tanstack/react-query';

type GetBajContactMessagesParams = {
  contactId: string;
  receiverId: string;
};

const getBajContactMessages = async (
  params: GetBajContactMessagesParams
): Promise<ChatMessageResponse[]> => {
  return (
    await axios.get(
      `bajs/${params.receiverId}/contacts/${params.contactId}/messages`
    )
  ).data;
};

export const useGetBajContactMessages = (params: GetBajContactMessagesParams) => {
  return useQuery({
    queryKey: ['messages', params.contactId, params.receiverId],
    queryFn: () => getBajContactMessages(params),
  });
};

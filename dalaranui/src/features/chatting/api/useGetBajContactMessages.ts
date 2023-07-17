import { axios } from '@/lib/axios';
import { ChatMessageResponse } from '../types';

type GetBajContactMessagesParams = {
  contactId: string;
  receiverId: string;
};

const getBajContactMessages = async (
  params: getBajContactMessagesParams
): Promise<ChatMessageResponse> => {
  return (
    await axios.get(
      `bajs/${params.receiverId}/contacts/${params.contactId}/messages`
    )
  ).data;
};

export const useGetBajContactMessages = (params: getBajContactMessagesParams) => {};

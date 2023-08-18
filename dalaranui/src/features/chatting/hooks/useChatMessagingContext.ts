import { useContext } from 'react';
import { ChatMessagingContext } from '@/features/chatting';

export const useChatMessagingContext = () => {
  const context = useContext(ChatMessagingContext);
  if (!context) {
    throw new Error('chat context should not be null when calling this method');
  }
  return context;
};

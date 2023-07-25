import { createContext, useState } from 'react';
import { ChatMessagingContextType } from '../types';
import { HubConnection } from '@microsoft/signalr';
import { useChatMessaging } from '../hooks/useChatMessaging';
import { useAuth } from '@/features/auth';

export const ChatMessagingContext = createContext<ChatMessagingContextType | null>(
  null
);

type Props = {
  children: React.ReactNode;
};

export const ChatMessagingProvider: React.FC<Props> = ({ children }) => {
  const auth = useAuth();
  const {} = useChatMessaging();

  return <div>{children}</div>;
};

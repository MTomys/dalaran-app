import { createContext, useState } from 'react';
import {
  ChatMessagingContextType,
  ReceiveChatMessageParams,
} from '@/features/chatting/types';
import { useChatMessaging } from '../hooks/useChatMessaging';
import { useAuth } from '@/features/auth';
import { useBajContext } from '@/features/bajs';

export const ChatMessagingContext = createContext<ChatMessagingContextType | null>(
  null
);

type Props = {
  children: React.ReactNode;
};

export const ChatMessagingProvider: React.FC<Props> = (props) => {
  const auth = useAuth();
  const bajContext = useBajContext();

  const [chatMessageReceivedHandler, setChatMessageReceivedHandler] = useState<
    null | ((ReceiveChatMessageParams: ReceiveChatMessageParams) => void)
  >(null);

  const { sendMessage } = useChatMessaging({
    authToken: auth.authState.token,
    onChatMessageReceive: chatMessageReceivedHandler,
  });

  return (
    <ChatMessagingContext.Provider
      value={{
        userId: bajContext.bajState.bajId,
        userProfileName: bajContext.bajState.bajProfileName,
        sendMessage: sendMessage,
        setChatMessageReceivedHandler: setChatMessageReceivedHandler,
      }}
    >
      {props.children}
    </ChatMessagingContext.Provider>
  );
};

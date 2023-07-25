import { HubConnection } from '@microsoft/signalr';

export type ChatMessagingContextType = {
  userId: string;
  userProfileName: string;
  connection: HubConnection;
};

export type ChatMessageResponse = {
  sender: string;
  receiver: string;
  content: string;
  timestamp: string;
};

export type ReceiveChatMessageParams = {
  sender: string;
  receiver: string;
  content: string;
};

export type SendChatMessageParams = {
  sender: string;
  receiver: string;
  content: string;
  timestamp: string;
};

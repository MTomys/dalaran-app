export type ChatMessagingContextType = {
  userId: string;
  userProfileName: string;
  sendMessage: (sendMessageParams: SendChatMessageParams) => Promise<void>;
  setChatMessageReceivedHandler: (
    chatMessageReceiveHandler:
      | null
      | ((receiveChatMessageParams: ReceiveChatMessageParams) => void)
  ) => void;
};

export type ChatMessageResponse = {
  sender: string;
  receiver: string;
  content: string;
  timestamp: string;
};

export type ReceiveChatMessageParams = {
  sender: string;
  recipient: string;
  content: string;
  timestamp: string;
};

export type SendChatMessageParams = {
  sender: string;
  recipient: string;
  content: string;
};

export type ReceiveMessageParams = {
  sender: string;
  recipient: string;
  content: string;
};

import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import {
  ChatMessageTextBox,
  ChatMessages,
  SendChatMessageParams,
  useChatMessaging,
} from '@/features/chatting/index';
import { useState } from 'react';

type Props = {
  contactImage: string;
  contactId: string;
  contactProfileName: string;
  bajId: string;
  bajProfileName: string;
};

export const ChatMessageWindow: React.FC<Props> = (props) => {
  const { contactImage, contactProfileName, contactId, bajId } = props;

  const { sendMessage } = useChatMessaging();

  const messagesQuery = useGetBajContactMessages({ contactId, bajId });

  const handleChatMessageSend = async (params: SendChatMessageParams) => {
    await sendMessage(params);
  };

  if (messagesQuery.isLoading) {
    return <div>Loading...</div>;
  }

  if (messagesQuery.isError) {
    return <pre>{JSON.stringify(messagesQuery.error)}</pre>;
  }
  return (
    <>
      <div>
        <div>image: {contactImage}</div>
        <span>You're chatting with: {contactProfileName}</span>
        <ChatMessages messages={messagesQuery.data} />
      </div>
      <ChatMessageTextBox
        sender="biggdawg1"
        recipient={contactProfileName}
        onChatMessageSend={handleChatMessageSend}
      />
      <div></div>
    </>
  );
};

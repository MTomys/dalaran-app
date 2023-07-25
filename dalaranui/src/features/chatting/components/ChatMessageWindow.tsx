import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import {
  ChatMessageTextBox,
  ChatMessages,
  useChatMessaging,
} from '@/features/chatting/index';
import { useState } from 'react';

type Props = {
  image: string;
  profileName: string;
  contactId: string;
  receiverId: string;
};

export const ChatMessageWindow: React.FC<Props> = (props) => {
  const { image, profileName, contactId, receiverId } = props;
  const [messages, setMessages] = useState('');

  const { sendMessage, checkConnectionState } = useChatMessaging();

  const messagesQuery = useGetBajContactMessages({ contactId, receiverId });

  if (messagesQuery.isLoading) {
    return <div>Loading...</div>;
  }

  if (messagesQuery.isError) {
    return <pre>{JSON.stringify(messagesQuery.error)}</pre>;
  }

  return (
    <>
      <div>
        <div>image: {image}</div>
        <span>You're chatting with: {profileName}</span>
        <ChatMessages messages={messagesQuery.data} />
      </div>
      <ChatMessageTextBox />
      <div></div>
    </>
  );
};

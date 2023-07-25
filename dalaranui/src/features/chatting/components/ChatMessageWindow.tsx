import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import { ChatMessages, useChatMessaging } from '@/features/chatting/index';
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

  const onSendMessageClick = async () => {
    sendMessage('testuser', 'testmessage');
  };

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
      <p>Messages received: {messages}</p>
      <button onClick={onSendMessageClick} className="bg-red-500 px-4 py-2">
        Click this:
      </button>
      <button onClick={checkConnectionState} className="bg-red-500 px-4 py-2">
        Connection state:
      </button>
    </>
  );
};

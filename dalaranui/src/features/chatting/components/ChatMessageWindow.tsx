import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import { ChatMessages } from '@/features/chatting/index';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect, useState } from 'react';

type Props = {
  image: string;
  profileName: string;
  contactId: string;
  receiverId: string;
};

export const ChatMessageWindow: React.FC<Props> = (props) => {
  const { image, profileName, contactId, receiverId } = props;
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [messages, setMessages] = useState('');

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl('/chatMessageHub')
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  const messagesQuery = useGetBajContactMessages({ contactId, receiverId });

  if (messagesQuery.isLoading) {
    return <div>Loading...</div>;
  }

  if (messagesQuery.isError) {
    return <pre>{JSON.stringify(messagesQuery.error)}</pre>;
  }

  return (
    <>
      <p>Chat window:</p>
      <div>
        <div>image: {image}</div>
        <span>You're chatting with: {profileName}</span>
        <ChatMessages messages={messagesQuery.data} />
      </div>
      <p>Messages received: {messages}</p>
    </>
  );
};

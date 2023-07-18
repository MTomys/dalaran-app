import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import { ChatMessages } from '@/features/chatting/index';

type Props = {
  image: string;
  profileName: string;
  contactId: string;
  receiverId: string;
};

export const ChatMessageWindow: React.FC<Props> = (props) => {
  const { image, profileName, contactId, receiverId } = props;

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
    </>
  );
};

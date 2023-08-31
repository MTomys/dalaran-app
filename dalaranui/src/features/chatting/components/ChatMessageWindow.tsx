import { useGetBajContactMessages } from '../api/useGetBajContactMessages';
import {
  ChatMessageTextBox,
  ChatMessages,
  SendChatMessageParams,
  useChatMessagingContext,
} from '@/features/chatting/index';

type Props = {
  contactImage: string;
  contactId: string;
  contactProfileName: string;
  bajId: string;
  bajProfileName: string;
};

export const ChatMessageWindow: React.FC<Props> = (props) => {
  const { contactImage, contactProfileName, contactId, bajId, bajProfileName } =
    props;

  const { sendMessage, setChatMessageReceivedHandler, userId, userProfileName } =
    useChatMessagingContext();

  setChatMessageReceivedHandler((params) => {
    console.log('incoming messageParams: ', params);
  });

  const handleChatMessageSend = async (params: SendChatMessageParams) => {
    console.log('params send message: ', params);
    await sendMessage(params);
  };

  const messagesQuery = useGetBajContactMessages({ contactId, bajId });
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
        sender={bajProfileName}
        recipient={contactProfileName}
        senderId={bajId}
        recipientId={contactId}
        onChatMessageSend={handleChatMessageSend}
      />
    </>
  );
};

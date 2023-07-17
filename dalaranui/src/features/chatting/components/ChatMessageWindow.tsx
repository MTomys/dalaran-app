import { ChatMessages } from './ChatMessages';

type Props = {
  image: string;
  profileName: string;
  contactId: string;
  receiverId: string;
};

export const ChatMessageWindow: React.FC<Props> = () => {
  return (
    <div>
      <ChatMessages />
    </div>
  );
};

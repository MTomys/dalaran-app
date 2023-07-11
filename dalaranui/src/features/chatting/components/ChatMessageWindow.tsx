import { ChatMessages } from './ChatMessages';

type Props = {
  contactImage: string;
  contactName: string;
};

export const ChatMessageWindow: React.FC<Props> = () => {
  return (
    <div>
      <ChatMessages />
    </div>
  );
};

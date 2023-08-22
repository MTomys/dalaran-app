import React, { useState } from 'react';
import { SendChatMessageParams } from '@/features/chatting/types';

type Props = {
  sender: string;
  recipient: string;
  senderId: string;
  recipientId: string;
  onChatMessageSend: (params: SendChatMessageParams) => void;
};

export const ChatMessageTextBox: React.FC<Props> = (props) => {
  const { onChatMessageSend, sender, recipient, senderId, recipientId } = props;
  const [messageContent, setMessageContent] = useState('');

  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log('submitting...');
    console.log({ sender, recipient, messageContent });
    onChatMessageSend({
      sender,
      recipient,
      senderId,
      recipientId,
      content: messageContent,
    });
    setMessageContent('');
  };

  return (
    <div className="w-full p-1.5">
      <form onSubmit={handleFormSubmit}>
        <input
          type="text"
          className="w-full px-1 bg-black text-green-400"
          placeholder="type here..."
          onChange={(e) => setMessageContent(e.target.value)}
          value={messageContent}
        />
      </form>
    </div>
  );
};

import React, { useState } from 'react';
import { SendChatMessageParams } from '@/features/chatting/types';

type Props = {
  sender: string;
  recipient: string;
  onChatMessageSend: (params: SendChatMessageParams) => void;
};

export const ChatMessageTextBox: React.FC<Props> = (props) => {
  const { onChatMessageSend, sender, recipient } = props;
  const [messageContent, setMessageContent] = useState('');

  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log('submitting...');
    onChatMessageSend({ sender, recipient, content: messageContent });
  };

  return (
    <div className="w-full">
      <form onSubmit={handleFormSubmit}>
        <input
          type="text"
          className="w-full bg-black text-green-400"
          placeholder="type here..."
          onChange={(e) => setMessageContent(e.target.value)}
        />
      </form>
    </div>
  );
};

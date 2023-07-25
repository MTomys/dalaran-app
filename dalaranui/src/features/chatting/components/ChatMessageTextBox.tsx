import React, { useState } from 'react';

type Props = {
  sender: string;
  recepient: string;
  onChatMessageSend: () => void;
};

export const ChatMessageTextBox: React.FC<Props> = (props) => {
  const { onChatMessageSend, sender, recepient } = props;

  const [messageContent, setMessageContent] = useState('');
  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log('submitting...');
  };

  return (
    <div className="w-full">
      <form onSubmit={handleFormSubmit}>
        <input type="text" className="w-full bg-black" placeholder="type here..." />
      </form>
    </div>
  );
};

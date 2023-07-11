import { ChatMessage } from '@/features/chatting';

type Props = {
  messages: ChatMessage[];
};

export const ChatMessages: React.FC<Props> = (props) => {
  return (
    <ul>
      {props.messages.map((m) => (
        <li>
          <p>{m.sender}</p>
          <p>{m.receiver}</p>
          <p>{m.content}</p>
          <p>{m.timestamp}</p>
        </li>
      ))}
    </ul>
  );
};

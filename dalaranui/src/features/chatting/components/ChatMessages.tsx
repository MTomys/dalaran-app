import { ChatMessageResponse } from '@/features/chatting';

type Props = {
  messages: ChatMessageResponse[];
};

export const ChatMessages: React.FC<Props> = (props) => {
  return (
    <ul>
      {props.messages.map((m, i) => (
        <li key={i}>
          <p>{m.sender}</p>
          <p>{m.receiver}</p>
          <p>{m.content}</p>
          <p>{m.timestamp}</p>
        </li>
      ))}
    </ul>
  );
};

import { ChatMessageResponse } from '@/features/chatting';

type Props = {
  messages: ChatMessageResponse[];
};

export const ChatMessages: React.FC<Props> = (props) => {
  return (
    <ul className="h-96 border border-green-500 overflow-y-scroll">
      {props.messages.map((m, i) => (
        <li key={i}>
          <span>{m.sender}:</span>
          <p>{m.receiver}</p>
          <p>{m.content}</p>
          <br></br>
        </li>
      ))}
    </ul>
  );
};

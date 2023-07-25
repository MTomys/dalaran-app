import { ChatMessageResponse } from '@/features/chatting';

type Props = {
  messages: ChatMessageResponse[];
};

export const ChatMessages: React.FC<Props> = (props) => {
  return (
    <ul className="h-96 border border-green-500 overflow-y-scroll px-2">
      {props.messages.map((m, i) => (
        <li key={i} className={m.sender === 'biggdawg1' ? `text-end` : `text-start`}>
          <span className="text-lg text-green-300">{m.sender}:</span>
          <p className="text-base">{m.content}</p>
          <br></br>
        </li>
      ))}
    </ul>
  );
};

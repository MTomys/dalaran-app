import { BajContactResponse } from '@/features/bajs';

type Props = {
  bajContact: BajContactResponse;
};

export const BajContact: React.FC<Props> = (props) => {
  return (
    <li className="border border-green-500 w-32 rounded-md">
      <p>Baj:</p>
      <p>{props.bajContact.image}</p>
      <p>{props.bajContact.profileName}</p>
    </li>
  );
};

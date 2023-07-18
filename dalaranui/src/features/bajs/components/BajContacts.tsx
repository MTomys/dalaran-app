import { BajContactResponse } from '../types';
import { BajContact } from './BajContact';

type Props = {
  bajs: BajContactResponse[];
  onContactSelect: (selectedContact: BajContactResponse) => void;
};

export const BajContacts: React.FC<Props> = (props) => {
  console.log(props);
  return (
    <>
      <p>Baj contact list:</p>
      {props.bajs.length === 0 && <p>You have no baj friends</p>}
      <ol>
        {props.bajs.map((baj) => (
          <BajContact bajContact={baj} onContactSelect={props.onContactSelect} />
        ))}
      </ol>
    </>
  );
};

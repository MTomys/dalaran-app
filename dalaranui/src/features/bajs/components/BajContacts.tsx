import { useGetBajContacts } from '../api/useGetBajContacts';
import { useBajContext } from '../hooks/useBajContext';
import { BajContactResponse } from '../types';
import { BajContact } from './BajContact';

type Props = {
  bajs: BajContactResponse[];
  onContactSelect: (selectedContact: BajContactResponse) => void;
};

export const BajContacts: React.FC<Props> = (props) => {
  const { bajs, onContactSelect } = props;
  return (
    <>
      <p>Baj contact list:</p>
      {bajs.length === 0 && <p>You have no baj friends</p>}
      <ol>
        {bajs.map((baj) => (
          <BajContact
            key={baj.contactId}
            bajContact={baj}
            onContactSelect={onContactSelect}
          />
        ))}
      </ol>
    </>
  );
};

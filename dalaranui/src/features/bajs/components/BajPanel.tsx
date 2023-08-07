import React, { useState } from 'react';
import {
  BajContactResponse,
  BajContacts,
  useBajContext,
  useGetBajContacts,
} from '@/features/bajs';
import { ChatMessageWindow } from '@/features/chatting';

export const BajPanel: React.FC = () => {
  const { bajState } = useBajContext();
  const contactsQuery = useGetBajContacts({ bajId: bajState.bajId });
  const [selectedContact, setSelectedContact] = useState<BajContactResponse | null>(
    null
  );

  console.log(selectedContact);

  if (contactsQuery.isLoading) {
    return <div>Loading...</div>;
  }

  if (contactsQuery.isError) {
    return <pre>{JSON.stringify(contactsQuery.error)}</pre>;
  }

  return (
    <>
      <h1>Baj Panel</h1>
      <BajContacts
        bajs={contactsQuery.data}
        onContactSelect={setSelectedContact}
      ></BajContacts>
      {selectedContact != null && (
        <div className="w-1/2 mx-auto border border-green-500 rounded-lg">
          <ChatMessageWindow
            bajId={bajState.bajId}
            bajProfileName={bajState.bajProfileName}
            contactId={selectedContact.contactId}
            contactProfileName={selectedContact.profileName}
            contactImage={selectedContact.image}
            key={selectedContact.contactId}
          />
        </div>
      )}
    </>
  );
};

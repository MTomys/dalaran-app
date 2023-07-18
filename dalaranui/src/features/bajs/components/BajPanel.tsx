import React, { useState } from 'react';
import { BajContactResponse, BajContacts, useGetBajContacts } from '@/features/bajs';
import { ChatMessageWindow } from '@/features/chatting';

export const BajPanel: React.FC = () => {
  const testId = '00000000-0000-0000-0000-200000000001';
  const contactsQuery = useGetBajContacts({ bajId: testId });

  const [selectedContact, setSelectedContact] = useState<BajContactResponse | null>(
    null
  );

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
      {selectedContact != null ? (
        <ChatMessageWindow {...selectedContact} receiverId={testId} />
      ) : (
        <></>
      )}
    </>
  );
};

import React from 'react';
import { Authorization } from '@/index';
import { axios } from '@/lib/axios';

export const BajPanel: React.FC = () => {

  const getBajContacts = async () => {
    const response = await axios.get("bajs/contacts");
    console.log('response: ', response);
  }

  return (
    <Authorization rolesRequired={['baj']}>
      <h1>Baj Panel</h1>
      <button onClick={getBajContacts}> click me </button>
    </Authorization>
  );
};

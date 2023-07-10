import React, { useState } from 'react';
import { Authorization } from '@/index';
import { axios } from '@/lib/axios';
import { BajContactResponse, BajContacts } from '@/features/bajs';

export const BajPanel: React.FC = () => {
  const [bajs, setBajs] = useState<BajContactResponse[]>([]);

  const getBajContacts = async () => {
    const response = await axios.get('bajs/contacts');
    console.log('response: ', response);
    setBajs(response.data);
  };

  return (
    <Authorization rolesRequired={['baj']}>
      <h1>Baj Panel</h1>
      <button onClick={getBajContacts}> click me </button>
      <BajContacts bajs={bajs}></BajContacts>
    </Authorization>
  );
};

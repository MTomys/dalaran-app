import { Authorization } from '@/components/Authorization';
import React from 'react';
import { NewcomerBajRegistrationForm } from '@/features/newcomerBajs';

export const NewcomerBajPage: React.FC = () => {
  return (
    // <Authorization rolesRequired={[]}>
      <main>
        <h1>Newcomer baj page</h1>
        <NewcomerBajRegistrationForm/>
      </main>
    // </Authorization>
  );
};
